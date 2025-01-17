﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CLIPSNET;

namespace VehicleFluidDiagnosis
{
    class RouterTextBox : TextBox
    {
        private class RouterThreadBridge
        {
            public bool charNeeded = false;
            public bool closed = false;
            public List<Byte> charList = new List<Byte>();
        }

        private class TextBoxRouter : Router
        {
            delegate void AddTextCallback(string text);

            static int RouterTextBoxNameIndex = 0;
            private RouterTextBox m_RouterTextBox;
            public String routerName;

            public TextBoxRouter(
              RouterTextBox theTextBox)
            {
                m_RouterTextBox = theTextBox;
                routerName = "RouterTextBox" + RouterTextBoxNameIndex++;
            }

            public override bool Query(String logicalName)
            {
                if (logicalName.Equals(STANDARD_OUTPUT) ||
                    logicalName.Equals(STANDARD_INPUT))
                    return true;
                else
                    return false;
            }

            public void AddText(string text)
            {
                if (m_RouterTextBox.InvokeRequired)
                {
                    Form parentForm = m_RouterTextBox.FindForm();
                    AddTextCallback d = new AddTextCallback(AddText);
                    parentForm.Invoke(d, new object[] { text });
                }

                else

                { m_RouterTextBox.AppendText(text); }
            }

            public override void Print(String logicalName, String printString)
            {
                this.AddText(printString);
            }

            public override int Getc(String logicalName)
            {
                RouterThreadBridge theBridge = this.m_RouterTextBox.m_ThreadBridge;
                
                lock (theBridge)
                {
                    if (theBridge.closed)
                    {
                        this.m_RouterTextBox.attachedEnv.SetHaltExecution(true);
                        return -1;
                    }

                    if (theBridge.charList.Count == 0)
                    {
                        theBridge.charNeeded = true;
                        try
                        { Monitor.Wait(theBridge); }
                        catch (SynchronizationLockException e)
                        { Console.WriteLine(e); }
                        catch (ThreadInterruptedException e)
                        { Console.WriteLine(e); }
                    }

                    theBridge.charNeeded = false;
                    if (theBridge.closed)
                    {
                        this.m_RouterTextBox.attachedEnv.SetHaltExecution(true);
                        return -1;
                    }

                    Byte theByte = theBridge.charList[0];
                    theBridge.charList.RemoveAt(0);

                    return theByte;
                }
            }
            public override int Ungetc(String logicalName, int theChar)
            {
                lock (this.m_RouterTextBox.m_ThreadBridge)
                {
                    this.m_RouterTextBox.m_ThreadBridge.charList.Insert(0, (Byte)theChar);
                }
                return 0;
            }
        }

        private CLIPSNET.Environment attachedEnv;
        private TextBoxRouter m_TextBoxRouter;
        private RouterThreadBridge m_ThreadBridge;

        public RouterTextBox() : base()
        {
            m_TextBoxRouter = new TextBoxRouter(this);
            m_ThreadBridge = new RouterThreadBridge();
            this.AcceptsReturn = true;
            this.ReadOnly = true;
            this.Multiline = true;
        }

        public void AttachRouter(
        CLIPSNET.Environment theEnv,
        int priority)
        {
            attachedEnv = theEnv;
            theEnv.AddRouter(m_TextBoxRouter.routerName, priority, m_TextBoxRouter);
        }

        public void DetachRouter()
        {
            this.ReadOnly = true;
        }

        public void OnClosing()
        {
            lock (m_ThreadBridge)
            {
                m_ThreadBridge.closed = true;
                if (m_ThreadBridge.charNeeded)
                {
                    m_ThreadBridge.charNeeded = false;
                    Monitor.Pulse(m_ThreadBridge);
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            lock (m_ThreadBridge)
            {
                if (m_ThreadBridge.charNeeded)
                {
                    if (((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back)) &&
                        (attachedEnv.InputBufferCount() == 0))
                    { /* Ignore */ }
                    else
                    { this.ReadOnly = false; }
                }
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            this.ReadOnly = true;
        }

        protected override void OnKeyPress(
        KeyPressEventArgs e)
        {
            lock (m_ThreadBridge)
            {
                if (m_ThreadBridge.charNeeded)
                {
                    m_ThreadBridge.charList.AddRange(Encoding.UTF8.GetBytes(e.KeyChar.ToString()));
                    this.Select(this.TextLength, this.TextLength);
                    this.ScrollToCaret();
                    base.OnKeyPress(e);
                    m_ThreadBridge.charNeeded = false;
                    Monitor.Pulse(m_ThreadBridge);
                }
            }
        }
    }
}


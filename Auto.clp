


;deftemplates




(deftemplate Oils "Identifying Your Car's Oils"

    (slot  appearance
    (type SYMBOL)
    (allowed-symbols tan light-brown dark-brown thick-like-honey blackened-by-deposits)
    
    )
)

(deftemplate  Fluids "Identifying Car Fluids"

    (slot appearance
    (type SYMBOL)
    (allowed-symbols light-amber clear)
    
    )
    (slot smell
    (type SYMBOL)
    (allowed-symbols fishlike baby-oil)
    
    )
)

(deftemplate TransmissionFluids "Traits of transmission and transaxle fluids"

    (slot appearance
    (type SYMBOL)
    (allowed-symbols red bright-color oily transparent)
    
    )

    (slot smell
    (type SYMBOL)
    (allowed-symbols  burnt-smell  relatively-odorless)
    
    )

)

(deftemplate Coolants "Traits of vehicle coolants"

    (slot appearance
    (type SYMBOL)
    (allowed-symbols neon-yellow green)
    
    )

    (slot smell
    (type SYMBOL)
    (allowed-symbols sweet-like)
    )


)

(deftemplate Water "Identifying characteristics"

    (slot appearance
    (type SYMBOL)
    (allowed-symbols clear)
    
    )

    (slot smell
    (type SYMBOL)
    (allowed-symbols no-smell)
    
    )
)

(deftemplate Fuels  "Identifying characteristics"

    (slot appearance
    (type SYMBOL)
    (allowed-symbols clear amber brownish-red yellow-tint  brown-with-green-tint yellowish-green)
    
    )

    (slot smell
    (type SYMBOL)
    (allowed-symbols strong-odour strong-lingering-odour  cooking-oil  burnt-popcorn)
    )

    (slot touch
    (type SYMBOL)
    (allowed-symbols oily-feel waxy  cold  slippery)

    )
)

(deftemplate Washer "Identifying characteristics"
   (slot appearance
   (type SYMBOL)
   (allowed-symbol blue)
   )

   (slot smell
   (type SYMBOL)
   (allowed-symbols cleanser-odour sweet-smell)
   )

)

;end of deftemplates

;defrules

(defrule engine_oil "Identifying characteristics"

    (Oils(appearance   tan|light-brown))
    =>
      (printout t "It's engine oil that is leaking!!" crlf )
)

(defrule gear_oil  "Identifying characteristics"
    (Oils(appearance  dark-brown|thick-like-honey) );if dark brown and thick like honey
    =>
   (printout  t  "It's heavy gear oil that is leaking!!" crlf)
)

(defrule used_oil "Identifying characteristics"
    (Oils(appearance blackened-by-deposits))
    =>
    (printout t "It's used motor oil that is leaking!!" crlf)
)

(defrule  brake-fluid "Identifying characteristics"
    (Fluids (appearance light-amber|clear)
     (smell baby-oil|fishlike)
     )
    

    =>
   (printout t "Your car is leaking brake fluid"crlf
                "Leaking brakes are dangerous!!" crlf
                           "OR" crlf
                "Hydraulic fluid is leaking from the power steering system and is placing the system at risk!" crlf
                "DO NOT! drive your car have it towed to a mechanic."crlf
    )
)

(defrule Transmission "Identifying characteristics"
    (TransmissionFluids   (appearance red|bright-color|oily|transparent)
    (smell burnt-smell|relatively-odorless)
    )
    
    =>
    (printout t "This is a transmission fluid leak." crlf
                "Please locate the leak and determine if it was due to overfilling." crlf
                "A very small leak can be driven to the mechanic,however if it's a big leak,do not under any circumstances drive the car." crlf
                "Seek the services of a professional or trusted mechanic immediately." crlf
    )
)

(defrule Antifreeze "Identifying characteristics"
   (Coolants (appearance neon-yellow|green)
   (smell sweet-like)
 
   )
   
   =>
    (printout t "This is an antifreeze or coolant leak."crlf
               " "crlf
               "It means that a seal has failed or the engine is getting too hot, and the coolant is bubbling out of the system" crlf
               "Because the hot coolant expands, the system builds pressure, so be careful when checking a hot engine for leaks—coolant can burn!" crlf
               "If the coolant is coming out of the overflow reservoir, your engine is probably running too hot, and you need to have it looked at by a mechanic." crlf
               "If it is a very slow leak, check for drips around hoses and ﬁttings." crlf
               "If you have a high-pressure leak that streams out of an area due to corrosion or a seal failure, have your car towed to the mechanic." crlf
   )
)

(defrule H2o "Identifying characteristics"
   (Water(appearance  clear)
   (smell no-smell) )
   
   =>
     (printout t "It's water that is dripping"crlf
               "Water can drip off of your car for a number of reasons, most of them harmless."crlf
               "Most often,dripping water is coming from condensation on the air conditioner."crlf
               "Water may also condense in the exhaust system and be blown out of the tail pipes before the exhaust is hot enough to evaporate it."crlf
               "Water can also collect in areas after washing or driving through wet conditions" crlf
               " " crlf
               "If it's your engine cooling system that is leaking straight water, it may mean that that the system does not have any antifreeze" crlf
               "As such,there is need for concern as your car's engine CANNOT run on straight water" crlf
               " "crlf
               "If water is coming out of the transmission or any other system, you have a leak that is allowing water to get in."crlf
               "You need to have this checked IMMEDIATELY! because water corrodes and can be destructive." crlf
      )
)

(defrule Petrol  "Identifying characteristics"
  (Fuels (appearance brownish-red|yellow-tint)  (smell strong-odour) (touch cold) )
  
  =>
    (printout t "It's petrol that is leaking" crlf
              "If leak is caused by something other than over filling the tank, do NOT drive the car." crlf
              "Fuel leaks are very dangerous and potentially explosive."crlf
              "Call a mechanic if you find a fuel leak in your car"crlf
   )
)

(defrule Diesel "Identifying characteristics"
    (Fuels(appearance brown-with-green-tint|yellowish-green)
    (smell strong-lingering-odour)  
    (touch oily-feel|waxy)
    )

   =>
    (printout t "It's diesel that is leaking" crlf
              "If leak is caused by something other than overfilling the tank, do NOT drive the car." crlf
              "Fuel leaks are very dangerous and potentially explosive."crlf
              "Call a mechanic if you find a fuel leak in your car"crlf
              
       )
)



(defrule Bio-fuel  "Identifying characteristics"
  (Fuels (appearance clear|amber) 
  (smell cooking-oil|burnt-popcorn)
  (touch slippery) 
  )
  =>

   (printout t "It's bio-fuel that is leaking" crlf
              "If leak is caused by something other than overfilling the tank,DO NOT! drive the car." crlf 
              "Fuel leaks are very dangerous and potentially explosive."crlf 
              "Call a mechanic if you find a fuel leak in your car."crlf
   )

)

(defrule Windshield  "Identifying characteristics"
  (Washer(appearance blue)
        (smell  cleanser-odour|sweet-smell)
     )
  
  =>
   (printout t "It's windshield washer fluid that's leaking" crlf
              "Leaking washer fluid is nothing to panic about."crlf
              "Your car will keep running if it runs out of fluid, although it isn’t a good idea to run the system dry for too long."crlf
              " "crlf
              "You can have the leak fixed at your convenience."crlf
       )
)



;end of defrules
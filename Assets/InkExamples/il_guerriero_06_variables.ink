VAR beers = 0

Entrai nella taverna oscura, dove c'era odore di alcool e fumo...

Mi trovai davanti l'oste, che mi guardò con fare sospetto

-> oste

== oste

+ Dammi da bere[!], dissi con tono imperioso -> oste_ride

+ Per favore, vorrei da bere[...], chiesi educatamente -> oste_versa_birra

== oste_ride

L'oste mi rise in faccia....

-> oste

== oste_versa_birra

L'oste versò della buona birra in un un boccale e me lo porse

~ beers = beers + 1

Avevo bevuto {beers > 1: {beers} birre}{beers == 1: la mia prima birra}

-> oste

-> END
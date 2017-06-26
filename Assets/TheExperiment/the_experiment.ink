-> start

=== start

S: Ah John, eccoti! # pleased

J: Sai... vivo qui... # confused

S: Sei arrivato al momento giusto. Prova a bere questo. # happy # coffee_cup

J: ... Perché? # confused

S: E' un esperimento. # sarcastic

S: Non ti preoccupare, non ti ucciderà. # eyeroll

J: Le tue parole mi ispirano non mi ispirano molta fiducia. # sulking

J: Perché non lo provi tu? # concentrating

S: Non posso osservare gli effetti di un esperimento se sono io la cavia. # suspicious

J: Ovviamente. # eyeroll

J: (Voglio veramente farlo?) # frustrated

-> options

=== options

+ [Bevi il caffé]

J: Ok, proviamo...
-> drink_coffee

* [Non bere il caffé]
-> dont_drink_coffee

=== drink_coffee

S: Eccellente. # confident

S: Perfetto. Sono passati 30 minuti, come ti senti? # concentrating

J: Come un idiota che dovrebbe smetterla di incoraggiarti. # sulking

S: No, non va bene. # annoyed

S: Niente nausea? Vertigini? # explaining

J: Aspetta, cosa? # confused

S: Hmm... Dovrò rivedere alcune ipotesi… # suspicious

-> END

=== dont_drink_coffee

J: No grazie. L'ultima volta che ho bevuto un tuo caffé, ho passato la giornata scappando da un cane immaginario. # annoyed

S: L'allucinogeno era nel gas, non nel caffé. # eyeroll

J: Non va bene, Sherlock! # serious

S: Calmati! # sarcastic

J: (Cosa dovrei fare adesso?) # concentrating

* Parla con Sherlock

-> talk_to_sherlock

* Esci

-> leave

=== talk_to_sherlock

J: Sherlock...

S: Hai cambiato idea?

-> options

=== leave

J: Ok.... Buona fortuna.

-> END
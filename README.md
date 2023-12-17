# SlotMachine
Esercizio in WPF e console che si occupa di emulare una slot machine.

SLOT MACHINE
Creare una classe che permetta di rappresentare una slot machine: deve funzionare ogni moneta inserita da diritto ad una partita in cui  girano le tre rotelle della slot machine e appaiono tre simboli (nel nostro caso tre lettere a caso dall'alfabeto italiano).
L’utente per sole due volte può decidere di tenere una o più lettere apparse e far girare nuovamente le rotelle o fermarsi.
Una volta che si ferma:
- se c’è una coppia viene restituita una moneta 
- se c’è un tris di lettere uguali vengono restituite un numero di monete pari alla posizione in ordine alfabetico della lettera del tris(es. tre C corrispondono a 3 monete)
- se ci sono tre lettere consecutive (es. ABC oppure EFG) vengono restituite 50 monete 
- se ci sono tre Z allora è JACKPOT e vengono restituite 100 monetine
altrimenti non viene restituito nulla e si passa alla partita successiva inserendo una nuova monetina.
Le monete vinte possono essere rigiocate oppure riscosse dal giocatore. 


- Realizzare una libreria di classi C# con le classi relative alla SlotMachine
- Realizzare un programma WPF che usa la libreria di classi
- Realizzare un programma Console che usa la stessa libreria di classi

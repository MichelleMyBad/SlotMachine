# SlotMachine
Esercizio in WPF e console che si occupa di emulare una slot machine.<br><br>


<b>UML</b>

<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/f8afc921-775c-4817-8ddb-a71b6adaba55">
<br>
<br>

<details>
<summary>WPF</summary>

<b>Interfaccia grafica</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/c787b570-b08b-465a-85f5-07319d7dd5a7" width="400">
<br>
<br>
<b>Punteggi</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/69e43568-93eb-4041-a98f-571518fb73cf" width="400">

- se c’è una coppia viene restituita una moneta 
- se c’è un tris di simboli uguali vengono restituite un numero di monete pari alla posizione in ordine del simbolo(es. tre corone corrispondono a 7 monete)
- se ci sono tre simboli consecutive (es. ciliegia,limone,anguria oppure fiori,quadri,campanella) vengono restituite 50 monete 
- se ci sono tre 7 allora è JACKPOT e vengono restituite 100 monete
<br><br>


<b>Caselle e "Hold"</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/9d219b96-e9a4-4ded-9c2a-6ba09c9431e6" width="400">
<br>
Ogni casella mostra un rimbolo generato randomicamente. <br>È possibile mantenere il simbolo tramite il pulsante <i>"Hold"</i>, di modo che, al prossimo spin, il simbolo selezionato non cambi. È possibile fare questa operazione solo con due simboli per volta.<br>
Se cliccato nuovamente il tasto libererà il simbolo precedentemente mantenuto
<br><br>

<b>Inserimento e gestione del saldo</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/ad809dc6-8f6b-41d5-9f9d-5eb6f56d5a56" width="400">
<br>
È possibile aggiungere una quantità di monete definita dall'utente quando si vuole. Ogni moneta permetterà un massimo di 3 spin e, in caso si ottengano vincite, la vincita ottenuta verrà mostrata nella sezione apposita <i>"ultima vincita"</i> e aggiunta al saldo.
<br>
<br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/1d0e8cd1-7c7e-45a3-8f44-8fbb4169d3e5" width="200"><br>
Una volta selezionato il "cashout" il saldo verrà azzerato e apparirà un popup che indicherà la vincita ottenuta

<br>

<b>Spin</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/e27b3517-12b2-4a8a-a68a-3c4eff833b66" height="200">
<br>
Al click della manopola, avverrà uno spin che genererà randomicamente 3 nuove immagini (a meno che alcune di esse non siano state mantenute). Ogni moneta utilizzata permetterà 3 spin e, in caso si desideri, è possibile accettare il risultato ottenuto anche prima di finire tutti gli spin disponibili.

</details>



<details>
<summary>Console</summary>

<b>Interfaccia grafica iniziale</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/e8437f6e-7242-4706-a748-d9fb790693c1" width="400">
<br>
Nell'interfaccia grafica iniziale viene permesso all'utente soltanto di inserire il credito
<br>
<br>

<b>Interfaccia grafica completa</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/991ff451-5ebb-409a-8923-74960d691454" width="400"><br>
Dopo aver inserito il credito la prima volta verrà poi mostrata questa interfaccia, che permetterà all'utente di svolgere diverse operazioni
<br><br><br>
<b>Punteggi</b><br>

- se c’è una coppia viene restituita una moneta 
- se c’è un tris di lettere uguali vengono restituite un numero di monete pari alla posizione in ordine alfabetico della lettera del tris(es. tre C corrispondono a 3 monete)
- se ci sono tre lettere consecutive (es. ABC oppure EFG) vengono restituite 50 monete 
- se ci sono tre Z allora è JACKPOT e vengono restituite 100 monete

<br>

<b>"Aggiungi credito" e gestione del saldo</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/fcf8fd75-f10a-4946-8679-c2cb7e3fb787">
<br>
È possibile aggiungere una quantità di monete definita dall'utente. Ogni moneta permetterà un massimo di 3 spin e, in caso si ottengano vincite, la vincita ottenuta verrà mostrata nella sezione apposita <i>"ultima vincita"</i> e aggiunta al saldo.
<br>
<br>


<b>Lettere e "Mantieni/libera lettera"</b><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/207597da-3684-4295-b61d-650771a56e2d">
<br>
Dopo ogni <i>"Roll"</i> verranno mostrate tre lettere generate randmicamente<br>È possibile mantenere la lettera tramite l'opzione <i>"Mantieni/libera lettera"</i>
<br><br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/8afc9c4a-6f03-483d-ac88-8a66b1a640ae" width="400">
<br>
Una volta selezionata l'opzione ci verrà chiesto di selezionare quale lettera si desitera mantenere o liberare, quelle mantenute verranno mostrate nella sezione apposita "Lettere mantenute" mentre, in caso di "liberazione", la lettera precedentemente in quella sezione verrà rimossa.<br>
Le lettere mantenute rimarranno invariate al prossimo <i>"Roll"</i>
<br>
<br>

<b>"Accetta risultato corrente"</b><br>
Una volta utilizzata l'operazione <i>"Accetta risultato corrente"</i>, in caso la combinazione di lettere corrente possa restituire una vincita, questa vincita verrà riscattata immediatamente, resettando poi i roll rimasti
<br><br>


<b>Roll</b><br>
Con l'operazione <i>"Roll"</i>, verranno generate randomicamente 3 nuove lettere (a meno che alcune di esse non siano state mantenute)
<br><br>

<b>Cash out</b>
<br>
<img src="https://github.com/MichelleMyBad/SlotMachine/assets/127590227/b21f2ced-ca08-44e1-80d3-00b0b2b1e0c4">
<br>

una volta eseguito il cash out verrà riferita la vincita ottenuta all'utente, terminando poi il programma



</details>








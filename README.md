# GreenThumbProject

WPF project made as a final assignment for the course database developement with C# and Entity Framework Core

# CHANGE ENCRYPT KEY PATH TO MAKE IT WORK
# Sammanfattning och analys

Programmet är utvecklat för ett bolag fiktivt som erbjuder ett digitalt hjälpmedel för människor som är intresserade av trädgårdsodling.
I mitt program möts man först av en login-skärm där man antingen kan logga in eller skapa en ny användare. Efter man eventuellt skapat en användare och loggat in så möts man av huvudsidan i programmet som visar alla de registrerade växterna i programmet. Här kan man söka efter specifika plantor, lägga till nya plantor, visa en detaljerad vy av vald planta i nytt fönster, ta bort plantor, gå till sin trädgård eller logga ut.
Väljer man att gå till den detaljerade vyn av en planta kan man lägga till den i sin trädgård. 
Går man till sin trädgård ser man alla sina tillagda plantor i en lista.

Jag valde att använda mig ut av separata repositories för varje tabell i min databas och använda mig av Unit of work pattern för att lättare få tillgång och använda alla dessa repositories, detta var för jag tänkte i början att de de inte delade så många funktioner och inte behövde göra samma sak så ofta och det skulle gå snabbare på detta viset. Nu i efterhand hade jag nog ändå skapat ett generiskt repository som alla de andra repositoriesen hade kunnat ärva av då det ändå va en del funktionalitet som alla repos behövde. Om jag gjorde på det viset istället hade jag kunnat minimera upprepad kod.

Jag hade även byggt ut repositoriesen ännu mer och lagt all kod som har med tillgång till databasen där nu i efterhand. När jag skapade dem la jag till all funktionalitet som jag trodde jag behövde men senare i de olika rutorna använde jag ändå context och skrev ett query när jag skulle ha inkluderad data eller dylikt, jag inser själv nu att det varit betydligt smartare att lägga till den funktionaliteten i repositoriesen för att ha allt samlat och lättare kunna ändra det i framtiden även om jag bara använder den typen av query på ett enda ställe i koden just nu.

Appen använder sig av en statisk class som innehåller och håller koll på den inloggade användaren om det finns en, för att lätt ha tillgång till all information utan att behöva skicka med användaren mellan alla fönster. 

Jag lärde mig och tog även användning av hur man deklarerar bilder och liknande som resurser och hur man sedan använder appens lokala map som utgångspunkt för image source vilket gör så att oavsett vem som laddar ner appen så fungerar och visas bilden som den ska utan att man behöver ända några paths på egenhand.

Extra funktioner som jag kunnat tänka mig lägga till är, förmågan att ta bort plantor från sin garden, ändra sitt lösenord och email samt ändra uppgifter i plant.
Den virtuella trädgården hade också varit kul att försöka, min första tanke på hur man hade kunnat åstakomma detta hade varit ett grid av buttons och en combobox med alla plantorna som är tillagda i användarens, när användaren klickar på en av knapparna i grid:et så ändras knappens text till plantans namn, om den knappen redan har samma planta som text så går den tillbaka till tom. Om man skulle kunna spara detta hade jag nog gjort en ny tabell typ GardenLayout som är dependet/child av garden, där jag hade använt column + row + gardenId som Key.

Förövrigt är jag nöjd med hur min sökfunktion och sökbar fungerar, då jag tycker den är väldigt responsive och det va en av mina tidiga förbättringar i projektet istället för att använda mig utav en knapp. Projektet har varit en bra möjlighet att återanvända lärdommar från den förra kursen samt krystallisera det jag lärt mig i denna på ett bra vis.

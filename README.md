# GreenThumbProject

WPF project made as a final assignment for the course database developement with C# and Entity Framework Core

# Sammanfattning och analys

Programmet är utvecklat för ett bolag fiktivt som erbjuder ett digitalt hjälpmedel för människor som är intresserade av trädgårdsodling.
I mitt program möts man först av en login-skärm där man antingen kan logga in eller skapa en ny användare. Efter man eventuellt skapat en användare och loggat in så möts man av huvudsidan i programmet som visar alla de registrerade växterna i programmet. Här kan man söka efter specifika plantor, lägga till nya plantor, visa en detaljerad vy av vald planta i nytt fönster, ta bort plantor, gå till sin trädgård eller logga ut.
Väljer man att gå till den detaljerade vyn av en planta kan man lägga till den i sin trädgård. 
Går man till sin trädgård ser man alla sina tillagda plantor i en lista.

Jag valde att använda mig ut av separata repositories för varje tabell i min databas och använda mig av Unit of work pattern för att lättare få tillgång och använda alla dessa repositories, detta var för jag tänkte i början att de de inte delade så många funktioner och inte behövde göra samma sak så ofta och det skulle gå snabbare på detta viset. Nu i efterhand hade jag nog ändå skapat ett generiskt repository som alla de andra repositoriesen hade kunnat ärva av då det ändå va en del funktionalitet som alla repos behövde. Om jag gjorde på det viset istället hade jag kunnat minimera upprepad kod.

Appen använder sig av en statisk class som innehåller och håller koll på den inloggade användaren om det finns en, för att lätt ha tillgång till all information utan att behöva skicka med användaren mellan alla fönster. 

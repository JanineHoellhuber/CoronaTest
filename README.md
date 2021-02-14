# COVID-19 Screening

## Zusammenfassung-Razor Pages:
* Umsetzung mit Razor Pages
* Person(mit Name, Geburtstag, ...) muss sich anmelden können beziehungsweise registrieren wenn noch kein Account besteht.
* Durch eine SMS-Verifikation soll der Benutzer eine SMS erhalten mit Sicherheitscode den er dann eingeben muss (zur Sicherheit)
* Wenn man eingeloggt ist, hat man die Möglichkeit als Benutzer, dass man seine eigenen Stammdaten verändert oder eine neue Testung hinzufügt.

## Zusammenfassung-WPF:
* Mit Von und Bis Datum kann nach bestimmten Testungen gesucht werden. 
* Es soll zudem eingetragen werden können ob jemand als "negativ" oder "positiv" getestet wurde.
* Ein count zählt die bereits getesteten Personen.
## Statusbericht:

bis 15.2: 
* Webseite: zur Reservierung und Verwaltung von Test-Terminen
* WPF: zur Abarbeitung von Testreservierungen
    
* Umgesetzt:
* Import Controller
* Projektstruktur erstellt
* SMS-Verifikation
* Webseite
* WPF

## Probleme bei:
    * SMS verschicken 
    * WPF: 
        * Problem zwischen Window und ViewModel (Befehle werden nicht ausgeführt)
    


Aplikacja do zarz�dzania bud�etem- MoneyMind
Jest to aplikacja do zarz�dzania bud�etem stworzona przy u�yciu ASP.NET Core 8.0. Umo�liwia u�ytkownikom zarz�dzanie swoimi finansami, kategoryzowanie transakcji i �ledzenie przychod�w oraz wydatk�w. U�ytkownicy mog� wizualizowa� swoje dane finansowe za pomoc� wykres�w i monitorowa� swoje wydatki w czasie. Aplikacja posiada dwa rodzaje u�ytkownik�w: zwyk�ego i premium. U�ytkownicy premium maj� dost�p do bardziej szczeg�owych informacji oraz dodatkowych funkcji.

Wymagania
ASP.NET Core 8.0 
Visual Studio 
SQL Server (dla bazy danych)
Chart.js (do generowania wykres�w)
Entity Framework Core (do operacji na bazie danych)

Instalacja
1. Sklonuj lub pobierz repozytorium:
   git clone https://twoje-url-repozytorium
2. Zainstaluj wymagane zale�no�ci:
   Otw�rz rozwi�zanie w Visual Studio.
   Przywr�� pakiety NuGet: Narz�dzia -> Mened�er pakiet�w NuGet -> Przywr�� pakiety NuGet.
3. Skonfiguruj po��czenie z baz� danych:
   Otw�rz plik appsettings.json.
   Skonfiguruj odpowiedni �a�cuch po��czenia z SQL Server w sekcji LabProjectDbContextConnection (zmie� DESKTOP-0DG8HLA na nazw� swojego serwera):
   {
     "ConnectionStrings": {
       "LabProjectDbContextConnection": "Server=DESKTOP-0DG8HLA;Database=LabProject;Trusted_Connection=True;TrustServerCertificate=true"
     }
   }
4. Utw�rz i zastosuj migracje: Otw�rz Konsol� Mened�era Pakiet�w i uruchom poni�sze komendy:
   Add-Migration InitialCreate
   Update-Database
5. Dane testowe: Mo�esz u�y� poni�szych danych u�ytkownik�w testowych:
   U�ytkownik testowy 1 (Premium):
   Email: test@aa.pl
   Has�o: Haslo123!
   U�ytkownik testowy 2 (Zwyk�y):
   Email: no@premium.com
   Has�o: Haslo321!
6. Uruchom aplikacj�.

Struktura bazy danych:
Aplikacja u�ywa dw�ch g��wnych kontekst�w bazy danych: ApplicationDbContext � kontekst bazy danych powi�zany z Identity oraz LabProjectDbContext � kontekst aplikacji do zarz�dzania bud�etem.

Konfiguracja Aplikacji
Tabela Categories: U�ywana do definiowania kategorii transakcji (np. "Jedzenie", "Transport").
Tabela Transactions: Przechowuje poszczeg�lne transakcje finansowe (przychody lub wydatki).

Dost�pne Widoki:
1. Strona G��wna (dla niezalogowanych u�ytkownik�w)
Opis aplikacji i jej funkcji.
Linki do stron logowania i rejestracji.
2. Strona Logowania / Rejestracji
U�ytkownicy mog� zalogowa� si� lub zarejestrowa� konto.
3. Strona Dashboard (dla zalogowanych u�ytkownik�w)
U�ytkownicy mog� ogl�da� r�ne raporty i podsumowania finansowe.
U�ytkownicy Premium maj� dost�p do bardziej szczeg�owych raport�w.
Zawiera wykresy generowane przez Chart.js, kt�re wizualizuj� dane finansowe z ostatnich kilku miesi�cy.
4. Strona Categories (dla zalogowanych u�ytkownik�w)
U�ytkownicy mog� zarz�dza� swoimi kategoriami transakcji.
Ka�dy u�ytkownik mo�e spersonalizowa� kategorie wed�ug swoich potrzeb.
5. Strona Transactions (dla zalogowanych u�ytkownik�w)
U�ytkownicy mog� dodawa�, edytowa� i usuwa� transakcje.
U�ytkownicy mog� przegl�da� histori� swoich transakcji.
6. Strona Ustawienia (dla zalogowanych u�ytkownik�w)
U�ytkownicy mog� zaktualizowa� swoje dane osobowe, w tym e-mail, numer telefonu i has�o.
7. Strona Polityki Prywatno�ci (dost�pna dla wszystkich)
Wy�wietla polityk� prywatno�ci aplikacji.


Role U�ytkownik�w
U�ytkownik Premium: ma dost�p do dodatkowych funkcji, takich jak bardziej szczeg�owe raporty i analizy.
U�ytkownik Zwyk�y: mo�e przegl�da� podstawowe raporty i zarz�dza� swoimi transakcjami oraz kategoriami.



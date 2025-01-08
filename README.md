Aplikacja do zarz¹dzania bud¿etem- MoneyMind
Jest to aplikacja do zarz¹dzania bud¿etem stworzona przy u¿yciu ASP.NET Core 8.0. Umo¿liwia u¿ytkownikom zarz¹dzanie swoimi finansami, kategoryzowanie transakcji i œledzenie przychodów oraz wydatków. U¿ytkownicy mog¹ wizualizowaæ swoje dane finansowe za pomoc¹ wykresów i monitorowaæ swoje wydatki w czasie. Aplikacja posiada dwa rodzaje u¿ytkowników: zwyk³ego i premium. U¿ytkownicy premium maj¹ dostêp do bardziej szczegó³owych informacji oraz dodatkowych funkcji.

Wymagania
ASP.NET Core 8.0 
Visual Studio 
SQL Server (dla bazy danych)
Chart.js (do generowania wykresów)
Entity Framework Core (do operacji na bazie danych)

Instalacja
1. Sklonuj lub pobierz repozytorium:
   git clone https://twoje-url-repozytorium
2. Zainstaluj wymagane zale¿noœci:
   Otwórz rozwi¹zanie w Visual Studio.
   Przywróæ pakiety NuGet: Narzêdzia -> Mened¿er pakietów NuGet -> Przywróæ pakiety NuGet.
3. Skonfiguruj po³¹czenie z baz¹ danych:
   Otwórz plik appsettings.json.
   Skonfiguruj odpowiedni ³añcuch po³¹czenia z SQL Server w sekcji LabProjectDbContextConnection (zmieñ DESKTOP-0DG8HLA na nazwê swojego serwera):
   {
     "ConnectionStrings": {
       "LabProjectDbContextConnection": "Server=DESKTOP-0DG8HLA;Database=LabProject;Trusted_Connection=True;TrustServerCertificate=true"
     }
   }
4. Utwórz i zastosuj migracje: Otwórz Konsolê Mened¿era Pakietów i uruchom poni¿sze komendy:
   Add-Migration InitialCreate
   Update-Database
5. Dane testowe: Mo¿esz u¿yæ poni¿szych danych u¿ytkowników testowych:
   U¿ytkownik testowy 1 (Premium):
   Email: test@aa.pl
   Has³o: Haslo123!
   U¿ytkownik testowy 2 (Zwyk³y):
   Email: no@premium.com
   Has³o: Haslo321!
6. Uruchom aplikacjê.

Struktura bazy danych:
Aplikacja u¿ywa dwóch g³ównych kontekstów bazy danych: ApplicationDbContext – kontekst bazy danych powi¹zany z Identity oraz LabProjectDbContext – kontekst aplikacji do zarz¹dzania bud¿etem.

Konfiguracja Aplikacji
Tabela Categories: U¿ywana do definiowania kategorii transakcji (np. "Jedzenie", "Transport").
Tabela Transactions: Przechowuje poszczególne transakcje finansowe (przychody lub wydatki).

Dostêpne Widoki:
1. Strona G³ówna (dla niezalogowanych u¿ytkowników)
Opis aplikacji i jej funkcji.
Linki do stron logowania i rejestracji.
2. Strona Logowania / Rejestracji
U¿ytkownicy mog¹ zalogowaæ siê lub zarejestrowaæ konto.
3. Strona Dashboard (dla zalogowanych u¿ytkowników)
U¿ytkownicy mog¹ ogl¹daæ ró¿ne raporty i podsumowania finansowe.
U¿ytkownicy Premium maj¹ dostêp do bardziej szczegó³owych raportów.
Zawiera wykresy generowane przez Chart.js, które wizualizuj¹ dane finansowe z ostatnich kilku miesiêcy.
4. Strona Categories (dla zalogowanych u¿ytkowników)
U¿ytkownicy mog¹ zarz¹dzaæ swoimi kategoriami transakcji.
Ka¿dy u¿ytkownik mo¿e spersonalizowaæ kategorie wed³ug swoich potrzeb.
5. Strona Transactions (dla zalogowanych u¿ytkowników)
U¿ytkownicy mog¹ dodawaæ, edytowaæ i usuwaæ transakcje.
U¿ytkownicy mog¹ przegl¹daæ historiê swoich transakcji.
6. Strona Ustawienia (dla zalogowanych u¿ytkowników)
U¿ytkownicy mog¹ zaktualizowaæ swoje dane osobowe, w tym e-mail, numer telefonu i has³o.
7. Strona Polityki Prywatnoœci (dostêpna dla wszystkich)
Wyœwietla politykê prywatnoœci aplikacji.


Role U¿ytkowników
U¿ytkownik Premium: ma dostêp do dodatkowych funkcji, takich jak bardziej szczegó³owe raporty i analizy.
U¿ytkownik Zwyk³y: mo¿e przegl¹daæ podstawowe raporty i zarz¹dzaæ swoimi transakcjami oraz kategoriami.



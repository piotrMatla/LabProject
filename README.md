# MoneyMind

Aplikacja **MoneyMind** to narzêdzie do zarz¹dzania bud¿etem stworzone w technologii ASP.NET Core 8.0. Umo¿liwia u¿ytkownikom œledzenie przychodów i wydatków, kategoryzowanie transakcji oraz wizualizacjê danych finansowych za pomoc¹ wykresów. Aplikacja oferuje dwa typy u¿ytkowników: zwyk³ych i premium, przy czym u¿ytkownicy premium maj¹ dostêp do bardziej zaawansowanych funkcji.

## Wymagania

- **ASP.NET Core 8.0**
- **Visual Studio**
- **SQL Server** (do obs³ugi bazy danych)
- **Chart.js** (do generowania wykresów)
- **Entity Framework Core** (do operacji na bazie danych)

## Instalacja

1. **Sklonuj repozytorium:**
   ```bash
   git clone https://github.com/piotrMatla/LabProject.git
   ```

2. **Zainstaluj wymagane zale¿noœci:**
   - Otwórz rozwi¹zanie w Visual Studio.
   - Przywróæ pakiety NuGet:
     - Narzêdzia -> Mened¿er pakietów NuGet -> Przywróæ pakiety NuGet.

3. **Skonfiguruj po³¹czenie z baz¹ danych:**
   - Otwórz plik `appsettings.json`.
   - Skonfiguruj odpowiedni ³añcuch po³¹czenia z SQL Server w sekcji `LabProjectDbContextConnection` (zamieñ `DESKTOP-0DG8HLA` na nazwê swojego serwera):
     ```json
     {
       "ConnectionStrings": {
         "LabProjectDbContextConnection": "Server=DESKTOP-0DG8HLA;Database=LabProject;Trusted_Connection=True;TrustServerCertificate=true"
       }
     }
     ```

4. **Utwórz i zastosuj migracje:**
   - Otwórz Konsolê Mened¿era Pakietów i uruchom poni¿sze komendy:
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```

5. **Dane testowe:**
   Mo¿esz skorzystaæ z poni¿szych u¿ytkowników testowych:
   - **U¿ytkownik testowy 1 (Premium):**
     - Email: `test@aa.pl`
     - Has³o: `Haslo123!`
   - **U¿ytkownik testowy 2 (Zwyk³y):**
     - Email: `no@premium.com`
     - Has³o: `Haslo321!`

6. **Uruchom aplikacjê:**
   - Kliknij `Run` w Visual Studio.

## Struktura bazy danych

Aplikacja wykorzystuje dwa g³ówne konteksty bazy danych:
- **ApplicationDbContext** – kontekst zwi¹zany z Identity.
- **LabProjectDbContext** – kontekst aplikacji do zarz¹dzania bud¿etem.

### Tabele:
- **Categories:** Przechowuje kategorie transakcji (np. "Jedzenie", "Transport").
- **Transactions:** Przechowuje dane o transakcjach (przychody lub wydatki).

## Dostêpne widoki

### 1. **Strona G³ówna**
   - Widoczna dla niezalogowanych u¿ytkowników.
   - Opis funkcji aplikacji.
   - Linki do stron logowania i rejestracji.

### 2. **Strona Logowania / Rejestracji**
   - Umo¿liwia rejestracjê nowego konta oraz logowanie.

### 3. **Strona Dashboard**
   - Dostêpna dla zalogowanych u¿ytkowników.
   - Podsumowanie finansowe oraz raporty.
   - Wykresy generowane przez Chart.js prezentuj¹ce dane finansowe z ostatnich miesiêcy.
   - U¿ytkownicy premium maj¹ dostêp do bardziej szczegó³owych raportów.

### 4. **Strona Categories**
   - Umo¿liwia zarz¹dzanie kategoriami transakcji.
   - Mo¿liwoœæ personalizacji kategorii wed³ug potrzeb u¿ytkownika.

### 5. **Strona Transactions**
   - Dodawanie, edycja oraz usuwanie transakcji.
   - Historia transakcji u¿ytkownika.

### 6. **Strona Ustawienia**
   - Umo¿liwia aktualizacjê danych osobowych (email, numer telefonu, has³o).

### 7. **Strona Polityki Prywatnoœci**
   - Wyœwietla politykê prywatnoœci aplikacji.

## Role u¿ytkowników

### **U¿ytkownik Premium:**
   - Dostêp do zaawansowanych raportów i analiz.

### **U¿ytkownik Zwyk³y:**
   - Przegl¹d podstawowych raportów.
   - Zarz¹dzanie transakcjami i kategoriami.

---

**MoneyMind** to idealne rozwi¹zanie dla osób, które chc¹ efektywnie zarz¹dzaæ swoimi finansami i lepiej planowaæ swój bud¿et.

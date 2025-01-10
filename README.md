# MoneyMind

Aplikacja **MoneyMind** to narz�dzie do zarz�dzania bud�etem stworzone w technologii ASP.NET Core 8.0. Umo�liwia u�ytkownikom �ledzenie przychod�w i wydatk�w, kategoryzowanie transakcji oraz wizualizacj� danych finansowych za pomoc� wykres�w. Aplikacja oferuje dwa typy u�ytkownik�w: zwyk�ych i premium, przy czym u�ytkownicy premium maj� dost�p do bardziej zaawansowanych funkcji.

## Wymagania

- **ASP.NET Core 8.0**
- **Visual Studio**
- **SQL Server** (do obs�ugi bazy danych)
- **Chart.js** (do generowania wykres�w)
- **Entity Framework Core** (do operacji na bazie danych)

## Instalacja

1. **Sklonuj repozytorium:**
   ```bash
   git clone https://github.com/piotrMatla/LabProject.git
   ```

2. **Zainstaluj wymagane zale�no�ci:**
   - Otw�rz rozwi�zanie w Visual Studio.
   - Przywr�� pakiety NuGet:
     - Narz�dzia -> Mened�er pakiet�w NuGet -> Przywr�� pakiety NuGet.

3. **Skonfiguruj po��czenie z baz� danych:**
   - Otw�rz plik `appsettings.json`.
   - Skonfiguruj odpowiedni �a�cuch po��czenia z SQL Server w sekcji `LabProjectDbContextConnection` (zamie� `DESKTOP-0DG8HLA` na nazw� swojego serwera):
     ```json
     {
       "ConnectionStrings": {
         "LabProjectDbContextConnection": "Server=DESKTOP-0DG8HLA;Database=LabProject;Trusted_Connection=True;TrustServerCertificate=true"
       }
     }
     ```

4. **Utw�rz i zastosuj migracje:**
   - Otw�rz Konsol� Mened�era Pakiet�w i uruchom poni�sze komendy:
     ```bash
     Add-Migration InitialCreate
     Update-Database
     ```

5. **Dane testowe:**
   Mo�esz skorzysta� z poni�szych u�ytkownik�w testowych:
   - **U�ytkownik testowy 1 (Premium):**
     - Email: `test@aa.pl`
     - Has�o: `Haslo123!`
   - **U�ytkownik testowy 2 (Zwyk�y):**
     - Email: `no@premium.com`
     - Has�o: `Haslo321!`

6. **Uruchom aplikacj�:**
   - Kliknij `Run` w Visual Studio.

## Struktura bazy danych

Aplikacja wykorzystuje dwa g��wne konteksty bazy danych:
- **ApplicationDbContext** � kontekst zwi�zany z Identity.
- **LabProjectDbContext** � kontekst aplikacji do zarz�dzania bud�etem.

### Tabele:
- **Categories:** Przechowuje kategorie transakcji (np. "Jedzenie", "Transport").
- **Transactions:** Przechowuje dane o transakcjach (przychody lub wydatki).

## Dost�pne widoki

### 1. **Strona G��wna**
   - Widoczna dla niezalogowanych u�ytkownik�w.
   - Opis funkcji aplikacji.
   - Linki do stron logowania i rejestracji.

### 2. **Strona Logowania / Rejestracji**
   - Umo�liwia rejestracj� nowego konta oraz logowanie.

### 3. **Strona Dashboard**
   - Dost�pna dla zalogowanych u�ytkownik�w.
   - Podsumowanie finansowe oraz raporty.
   - Wykresy generowane przez Chart.js prezentuj�ce dane finansowe z ostatnich miesi�cy.
   - U�ytkownicy premium maj� dost�p do bardziej szczeg�owych raport�w.

### 4. **Strona Categories**
   - Umo�liwia zarz�dzanie kategoriami transakcji.
   - Mo�liwo�� personalizacji kategorii wed�ug potrzeb u�ytkownika.

### 5. **Strona Transactions**
   - Dodawanie, edycja oraz usuwanie transakcji.
   - Historia transakcji u�ytkownika.

### 6. **Strona Ustawienia**
   - Umo�liwia aktualizacj� danych osobowych (email, numer telefonu, has�o).

### 7. **Strona Polityki Prywatno�ci**
   - Wy�wietla polityk� prywatno�ci aplikacji.

## Role u�ytkownik�w

### **U�ytkownik Premium:**
   - Dost�p do zaawansowanych raport�w i analiz.

### **U�ytkownik Zwyk�y:**
   - Przegl�d podstawowych raport�w.
   - Zarz�dzanie transakcjami i kategoriami.

---

**MoneyMind** to idealne rozwi�zanie dla os�b, kt�re chc� efektywnie zarz�dza� swoimi finansami i lepiej planowa� sw�j bud�et.

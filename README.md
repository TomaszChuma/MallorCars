
# MallorCar

W tym pliku opiszę najważniejsze rzeczy dotyczące projektu takie jak kroki jakie należy podjąć aby poprawnie go uruchomić oraz najważniejsze założenia. W pliku docx załączę rozszerzoną wersję, w której zawierać się będzie opis podjętych kroków i procesu implementacji.


## Setup

W celu poprawnego uruchomienia projektu należy podjąć następujące kroki:

   1. Stworzyć kontener dockerowy przy użyciu komendy i uruchomić go:



```bash
  docker run
    --name mallorcar
    -p 5455:5432
    -e POSTGRES_USER=tomasz18
    -e POSTGRES_PASSWORD=notpass18
    -e POSTGRES_DB=MallorCar
    -d
    postgres
```
    
2. W lokalizacji MallorCar/MallorCar.BE uruchomić komendę

```bash
  dotnet ef database update -s MallorCar.API -p MallorCar.Infrastructure
```

3. Uruchomić inserty do naszej bazy danych(plik dbInserts.txt)
4. Uruchomić solucje
5. W lokalizacji MallorCar/MallorCar.FE uruchomić komendę

```bash
  npm start
```

## Ficzery

- Wybór lokalizacji początkowej i końcowej
- Wybór daty/czasu początku i końca wypożyczenia (kalendarz został skonstruowany tak aby uniknąć niepożądanych wyborów)
- Wyświetlanie samochodów dostępnych dla wybranych lokalizacji i dat wraz z szczegółami modelów oraz ilością dostępnych sztuk
- Stworzenie rezerwacji wraz ze wszystkimi danymi jej dotyczącymi
- Powiadomienie SMS oraz Email z informacjami dotyczącymi rezerwacji
- Możliwość sprawdzenia szczegółów rezerwacji na podstawie jej kodu otrzymanego w ww. wiadomościach
- Możliwość dodawania nowych samochodów
- Możliwość zmiany dziennej podstawy cenowej dla konkretnego modelu


## Demo

https://drive.google.com/file/d/1XvEMnZmcgbIAptw74FSQT5HbaFS5-o6Z/view?usp=sharing


## Założenia

#### Ustalanie dostępności samochodów w zadanym okresie czasu dla danego miejsca

Algorytm sprawdzania samochodów dostępnych w danych lokacjach w konkretnych ramach czasowych wymaga pewnych założeń. Dla każdego z pojazdów jego aktualne miejsce pobytu będzie się zmieniało na osi czasu. Załóżmy, że dostępne będą te pojazdy, które w danej lokacji miały koniec swojego wypożyczenia przed wskazaną przez klienta początkową datą jego planowanej rezerwacji, oraz przez ten okres czasu nie ma na nie innych rezerwacji. Jeśli po widocznym ostatnim wypożyczeniu(samochód teoretycznie mógłby być dostępny) dla konkretnego samochodu istnieje wypożyczenie między jego końcem, a naszym wskazanym początkiem oznacza to, że samochód jest niedostępny: 

1.	Zakończył wypożyczenie i został zwrócony w innym miejscu
2.	Wypożyczenie trwa


Po przefiltrowaniu od „lewej strony” rezerwacji pozostało nam sprawdzić czy nie ma innych rezerwacji na ten samochód w trakcie zadanych dat. Jeśli żadna z rezerwacji nie zaczyna się w tym czasie oznacza to, że samochód jest w pełni dostępny 



#### Co jeśli samochód biorąc pod uwagę wyżej wymienione założenia zostanie poprawnie zarezerwowany ale zwrócony w innym miejscu?

Pan X chce zarezerwować pojazd od 20.03 w Palma Airport i system mu na to pozwala bo ktoś zostawił tam dany model 10.03. System pomyślnie akceptuje operacje. Powinniśmy ustalić dodatkowe filtry, które usuną z listy samochody, które w zadanych ramach czasowych są już zajęte(i to też jest do zrobienia). Problem pojawia się wtedy gdy w dniach 11.03 -19.03 ktoś będzie chciał wypożyczyć dane auto, ale zwróci je już w innej lokacji. I tu wtrąca się czynnik ludzki czyli założenie, że pracownicy firmy w wyznaczonym czasie, bądź przed wypożyczeniem transportują pojazd na miejsce. Mając mało pojazdów taka optymalizacja jest tym bardziej ważna. Nie możemy przewidzieć przyszłości i wiedzieć jak będzie wyglądać lista samochodów dokładnie w danym dniu bo po drodze mogą dochodzić kolejne zamówienia.


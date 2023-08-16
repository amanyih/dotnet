select firstName, lastName, city, state from Person Left join Address on Address.personId = Person.personId

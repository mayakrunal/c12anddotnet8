TimesTable(7, 10);

//ConfigureConsole("fr-FR");

decimal taxToPay = CalculateTax(149, "FR");

WriteLine($"You must pay {taxToPay:C} in tax.");

RunFactorial();

RunFibFunctional();
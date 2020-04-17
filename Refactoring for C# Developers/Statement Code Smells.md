###Primitive Obsession:
*Overuse of primitives, instead of better abstractions or data structures*
```
	AddHoliday(7, 4) //not clear which number is day and which is month

	Date independenceDay = new Date(month: 7, day: 4);
	AddHoliday(independenceDay);
```

###Vertical Separation:
*Design, assign, and use variables and functions newar where they are used.*
*Define local variables where first used, ideally as they are assigned.*
*Define private functions just below their first use. Avoid forcing the reader scroll.*

###Inconsistency:
*Be consistent in your naming, formatting, and usage patterns within your application*

###Poor Names:
*Naming things has often been cited as one of the hardest prlblems in computer science. *
*Use descriptive names and avoid abbreverations and encodings where possible.*

###Switch Statements:
*Avoid multiple switch cases*

###Duplicate Code:
**

###Dead Code:
**

###Hidden Temporal Coupling
*Certain operations must be called in a certain sequence, ot they won't work.*
*Nothing in the design forces this behaviour - developers just have to figure it out from context or tribal knowledge.*
```
	//making pizza should follow the order. here we not protected against mixing these method calls.
	PrepareCrust();
	AddTopings();
	Bake();
	CutIntoSlices();
```

```
	Crust crust = PrepareCrust();
	ToppedCrust toppedCrust = AddToppings(crust);
	BakedItem bakedItem = Bake(toppedCrust);
	SlicedItem slicedItem = CutIntoSlices(bakedItem);
```
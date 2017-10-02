# Datab
Simple database class for C#

## How to import Datab into your project
The included `Datab.cs` should be imported into your C# project as a class. That's it.

## How does Datab work?
Datab works a lot like a 2D array or an Excel spreadsheet. Labels are the titles for columns, and content (a.k.a entries) is what makes up the database. For example, you might have labels like "Username", "Password", or "ID", and your content would be something along the lines of "niorg2606|password|1" respectively.

## Documentation
`Init()` as void: Initialize the database for use. It's recommended that you put this in a function that gets called as soon as your project is run.

`SetLabel(int at, string name)` as void: Set a label at the variable `at` and with a name of `name`. `SetLabel(0,"Username")` woud set the first label as "Username".

`GetLabel(int at)` as string: Returns the name of the label at position `at`. If you ran the example for `SetLabel()` above and called `GetLabel(0)`, it would return "Username".

`GetLabels()` as List<string>: Get a list of all the labels. Pretty straightforward.

`GetLabelID(string name)`as string: Finds the position of a label with the name of `name`. Continuing the above examples, `GetLabelID("Username")` would return `"0"`.

`GetContent(int labelID, int entry)` as string: Get the specific item of an entry `entry` under the label `labelID`.

`GetContent(string label, int entry)` as string: Same as `GetContent(int labelID, int entry)`, but for when you know the name of the label the content is under and not the ID.

`NewEntry(List<string> content)` as void: Insert a new entry as the end of your database. `content.Length` should be the same as the amount of labels there are in your database.

`GetAllContent()` as List<List<string>>: Get all of the content in your database as a 2D list (System.Collections.Generic).

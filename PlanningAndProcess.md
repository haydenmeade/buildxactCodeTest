## Plan

1. Inspect data and create model classes
 -- NodaMoney for currency handling

2. Create model reader interface and classes. 
 -- (CsvHelper, newtonsoft)
 --* make readers async

3. Read data into one array, sort by price (In AUD), Print
 -- Exchange rate in configuration file.

*4. Add tests if possible

Keep in mind:
Commented code and process
Keep it simple 

## Process

Data is different, will need interface with 2 classes
I don't like having the 2 classes in the end. I want to implement some custom json reading.

# Improvements

Add more unit tests
Improve the readers
 -- Extract file reading to a dependency so the classes are testable.
Overall there are some missing comments on the classes 
Class inputs should be verified
It would be nice to have some sort of ReaderFactory, this would allow the Program logic to be cleaned up a bit.
Exchange rate logic could be improved if there are more exchange rates needed.
Readers could be async, but doesn't really need to be done in this console application.


// Problem 5: Write a function that finds the youngest person in a given array of persons and prints his/hers full name.
// Each person have properties firstname, lastname and age.

var lowestAge = 150,
    position = 0;

function findYoungest (personsArray) {
    for (var i in personsArray) {
        if (personsArray[i].age < lowestAge) {
            lowestAge = personsArray[i].age;
            position = i;
        }
    }
    return personsArray[position].firstname + ' ' + personsArray[position].lastname + ' ' + personsArray[position].age;
}

var persons = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Pesho', lastname: 'Peshev', age: 21 },
    { firstname: 'Dwayne', lastname: 'Johnson', age: 42 }];

var lowestAgePerson = findYoungest(persons);
console.log(lowestAgePerson);
/*
Write a function that groups an array of persons by age, first or last name. The function must return an associative array,
with keys - the groups, and values -arrays with persons in this groups.
Use function overloading (i.e. just one function).
*/

function Person(firstName, lastName, age) {
    if (!(this instanceof Person)) {
        return new Person(firstName, lastName, age);
    }

    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

Person.prototype.toString = function () {
    return this.firstName + ' ' + this.lastName + ' - ' + this.age;
};

function group(persons, property) {
    switch (property) {
        case 'firstName':
        case 'lastName':
        case 'age':
            {
                var groups = {};

                persons.map(function (p) {
                    groups[p[property]] = groups[p[property]] || [];
                    groups[p[property]].push(p);
                });
                return groups;
            }
        default:
            throw new Error('Property not found!');
    }
}

function printResult(message, persons) {
    console.log(message);

    for (var i in persons) {
        console.log('Key: ' + i);
        console.log('-> ' + persons[i]);
    }
}

var persons = [
    Person('Gosho', 'Petrov', 32),
    Person('Bay', 'Ivan', 81),
    Person('Pesho', 'Peshev', 21),
    Person('Dwayne', 'Johnson', 42)];

var groupedByAge = group(persons, 'age');
printResult('Grouped by age', groupedByAge);

//var groupedByFirstName = group(persons, 'firstName');
//printResult('Grouped by firstName', groupedByFirstName);

//var groupedByLastName = group(persons, 'lastName');
//printResult('Grouped by lastName', groupedByLastName);
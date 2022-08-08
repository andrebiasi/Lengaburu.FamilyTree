# Lengaburu.FamilyTree (Meet The Family)
Meet The Family is a CLI application for:
* Adding a child to the family.
* Searching relationship for a given person.
It takes a text file as input and display the results on the screen.

## Pre-requisites
.NET Core 2.1

## Notes
* Initial Family Members and their relationships have been pre-loaded.

## Assumptions
* King Arthur and Queen Margret have been loaded without their titles. Therefore, only the names should be used.
Arthur instead of King Arthur.
Margret instead of Queen Margret.
* Two people with the same name are not allowed.
* Only single names are allowed.

## How to run the tests
`./build/run_tests.sh`

## How to build app
`./build/build_app.sh`

## How to Run
`./build/run_app.sh <input.txt>`

## Adding a child
### Input file
`ADD_CHILD <mother's name> <child's name> <child's gender>`
### Outputs
`CHILD_ADDITION_SUCCEEDED`
`CHILD_ADDITION_FAILED`
`PERSON_NOT_FOUND`
### Example
* input.txt
`ADD_CHILD Mary Bob Male`
* Output
`CHILD_ADDITION_SUCCEEDED`

## Getting relationship
### Input file
`GET_RELATIONSHIP  <name> <relationship>`
### Outputs
`name1 name2... nameN`
`NONE`
`PERSON_NOT_FOUND`
### Valid relationships
* Paternal-Uncle
* Maternal-Uncle
* Paternal-Aunt
* Maternal-Aunt
* Sister-In-Law
* Brother-In-Law
* Son
* Daughter
* Siblings
### Example
* input.txt
`GET_RELATIONSHIP Bob Son`
* Output
`Mike Doug`

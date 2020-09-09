# 200909 Forms Lecture

## Set Up
- clone application and open in vscode
- accept extension suggestions (generates vscode folder)
- accept missing imports (resolves entity framework core errors)
- view application in browser
- import postman collection

## Code Together
### Create
- add link to add writer in navigation bar
- add controller action to display Writer Form
- create Writer Form View using the HTML form helper tags to bind to Writer Model
- submit writer form to add writer POST method and redirect to view all writers if add is successful 
- if the model throws an error, display the error(s) above the form and re-populate form with the input values

### Update
- add a button to edit a writer in the view one view, passing in the writer ID
- add a controller action that accepts a writer ID and passes the matching writer to a view that displays a populated form using the HTML form helper tags to bind to Writer Model
- submit writer form to add writer POST method and redirect to view all writers if update is successful 
- if the model throws an error, display the error(s) above the form and re-populate form with the input values

### Delete
- add a button to delete a writer by id in the view one view
- delete writer from existing method and redirect to view all writers

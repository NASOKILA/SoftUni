import { TodoFormComponent } from './todo-form.component'; 
import { FormBuilder } from '@angular/forms';

describe('TodoFormComponent', () => {
  
  var form: TodoFormComponent; 

  beforeEach(() => {
    //before each test we assign new TodoFormComponent(new FormBuilder()) to the form
    form = new TodoFormComponent(new FormBuilder())
  });
  
  it('Should contain name field.', () => {
    expect(form.form.contains("name")).toBeTruthy();
  });

  it('Should contain email field.', () => {
    expect(form.form.contains("email")).toBeTruthy();  
  });

});
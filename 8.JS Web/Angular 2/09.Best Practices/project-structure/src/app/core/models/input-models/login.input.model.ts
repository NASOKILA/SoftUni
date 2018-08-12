export class LoginInputModel {
  constructor(
    public username : string,
    public password : string
  ) { } 
}

// Components that will use this model
// LoginFormComponent (two-way data binding)
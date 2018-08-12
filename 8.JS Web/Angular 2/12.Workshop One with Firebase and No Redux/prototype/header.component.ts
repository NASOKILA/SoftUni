export class HeaderComponent implements OnInit {
  dropdownLi : string = "nav-item dropdown";
  dropdownMenu : string = "dropdown-menu";

  ngOnInit() {
  }

  expand() {
    this.dropdownLi.endsWith('show') 
    ? this.dropdownLi = "nav-item dropdown" 
    : this.dropdownLi = "nav-item dropdown show";

    this.dropdownMenu.endsWith('show')
    ? this.dropdownMenu = "dropdown-menu"
    : this.dropdownMenu = "dropdown-menu show";
  }

}

//we will create a directive and use it to change the css 
//HostListener handles events
import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
    selector: '[appHighlight]'
})

//we change the color
export class HighlightDirective {
    constructor(private el : ElementRef){
        this.el.nativeElement.style.background = 'yellow';
    }

    private highlight(color : string) {
        this.el.nativeElement.style.background = color;        
    }

    //whe we hover the color is red
    @HostListener('mouseenter') onMouseEnter() {
        this.highlight('red');
    }

    //whe we leave the color is green
    @HostListener('mouseleave') onMouseLeave() {
        this.highlight('green');
    }
}

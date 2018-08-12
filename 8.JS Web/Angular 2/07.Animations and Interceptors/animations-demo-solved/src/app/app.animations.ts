

//we will need the following things from '@angular/animations';
import { 
  trigger,
  state,
  animate,
  transition,
  style,
  keyframes,
  group
 } from '@angular/animations';

const appAnimations =  [

  //This is a transition
  //name of the trigger
  trigger('divState', [

    //we can have many states
    //state normal css
    state('normal', style({
      backgroundColor: 'red',
      transform: 'translateX(0)'
    })),

    //state highlighted css
    state('highlighted', style({
      backgroundColor: 'blue',
      transform: 'translateX(100px)'
    })),

    //we define the direction of the animation and the time of execution, 300 miliseconds
    
    transition("normal => highlighted", animate(300)),
    transition("highlighted => normal", animate(600))

    //if we want the same speed for both directions we need '<=>'
        //transition("highlighted <=> normal", animate(300))

  ]),


  //Advanced transitions 
  //We can have several transitions at onse  
  trigger('wildState', [
    state('normal', style({
      backgroundColor: 'red',
      transform: 'translateX(0) scale(1)'
    })),
    state('highlighted', style({
      backgroundColor: 'blue',
      transform: 'translateX(100px) scale(1)'
    })),

    //this transition trigger holds an additional state to make it smaller and change background to green
    state('shrunken', style({
      backgroundColor: 'green',
      transform: 'translateX(0) scale(0.5)'
    })),
    transition("normal => highlighted", animate(300)),
    transition("highlighted => normal", animate(800)), //from highlighted to normal it goes slower
    transition('shrunken <=> *', [

      //when we shrink it its background becomes orange
      style({
        backgroundColor: 'orange'
      }),

      //and its shape changes to a sphere 
      animate(1000, style({
        borderRadius: '50px'
      })),

      //then a second later, it starts to become a green smaller square whitin 500 miliseconsd its done 
      //and if its not on the same position it returns to the initial position
      animate(500)
    ])
  ]),


  trigger('list1', [
    
    //void state is for adding new elements from nothing
    //'*' means all directions and its the list itself    
    transition("void => *", [

      //we add new element with the following css in 1 seconds speed
      style({
        opacity: 0,
        transform: 'translateX(-100px)'
      }),
      animate(1000)
    ]),

    // * is the list itself
    //here we remove elements, * => void means the opposite
    transition('* => void', [
      animate(1500, style({
        transform: 'translateX(100px)',
        opacity: 0
      }))
    ])
  ]),


  //keyframes we alreadi know them its similar to the ones in css
  trigger('list2', [

    transition("void => *", [
      animate(1000, keyframes([

        //here we decribe in details all the movements
        style({
          transform: 'translateX(-100px)',
          opacity: 0
        }),
        style({
          transform: 'translateX(-50px)',
          opacity: 0.5
        }),
        style({
          transform: 'translateX(-20px)',
          opacity: 0.7
        }),
        style({
          transform: 'translateX(0)',
          opacity: 1
        })
      ]))
    ]),

    //Grouping : It can invoke several animations at once 
    transition('* => void', [
      group([
        animate(1000, style({
          background: 'red',
        })),
        animate(800, style({
          transform: 'translateX(100px)',
          opacity: 0
         }))
      ])
    ])
  ])
]

export { appAnimations }
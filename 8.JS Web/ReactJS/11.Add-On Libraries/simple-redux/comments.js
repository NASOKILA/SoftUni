/*

    Redux & Flux:
        Redux slaga pravila za sledvane na vsichki koito polzvat React.js
        Flux e podobno.
        I dvete sledvat nqkkvi principi

        Mojem da podavame danni ot vutreshni komponenti kum vunshni.
        

        Instalirane:
            npm install --save redux

        Biblioteki:
            npm install --save immutable
            npm install --save-dev redux-devtools
            ADD CHROME DVTOOLS EXTENSION TO THE GOOGLE CHROME BROWSER


    Reduxsa raboti s 3 neshta;
        Actions,
        Reducers - updeitva state-a,
        Stores - Durji state-a i reducer-a

    Actions:
        Vseki action ima reducer koito updeitva state-a:
        Prashta dannite kum reducera.
        
    Reducers:
        Te opisvat kak actionite afektirat dannite.
        Te sa prosto funkcii koito ne promenqt podadenite im parametri.
        Kak se pishat ? 
            (previousState, action) => newState;

    Store:
        Durji actionite, state-a i reducerite
        Suedinqva ctionite i reducerite,
        durji state-a i pozvolqva updeitvane na nego.
            importva se createStore ot 'redux' 





    

    React Redux:
        npm install -g react-redux;
        
        V index.js:

            import { createStore, Provider } from 'react-redux'

            const store = createStore(rootReducer, InitialState)

            CELTA E VSICHKI DECA NA <App/> da mogat da dostupqt store !!!
            <Provider> 
                <App />  
            </Provider>



            Exposing Store State:
                Polzvat se funkcii za rabota sus state-a:
                
                
function mapStateToProps(state){
    return {
        appState: state
    }
}

        SEGA STATE-A SHTE GO VIJDAME POD this.props.appState

    Moje vsichki actioni (funkcii) da sa v otdelen fail koito da gi exportva i da gi baindnem zaedno 
*/


/*
    Middlewares:
        Uchili sme gi mojem da gi polzvame za store-a
        Priemat tri argumenta:
            (store, next, action) => {}
    

*/




/*
    SUMMARY:
        Redux - tova e neshto koeto ni ulesnqva rabotata sus state-a,
            slagame si state-a v nego i samo tam shte bude.
            Toi raboti s 3 neshta: Actioni, Reduceri i Store-ut

        Actionite - signalizirat za promqna
        
        Reducera - Opredelq kakvo da bude promeneno i updeitva applikaciqta i 
            state-a vuv store-a

        Store - durji state-a



*/
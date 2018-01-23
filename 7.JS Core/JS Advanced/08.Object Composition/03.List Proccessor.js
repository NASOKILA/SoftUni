


let solve = (function () {

    let list = [];

    function add(string) {
        list.push(string)
    }

    function remove(string) {

        let index = list.indexOf(string);

        while(index !== -1)
        {
            list.splice(index, 1);
            index = list.indexOf(string);
        }

    }

    function print(list) {
        console.log(list.join(','));
    }

    return function(args){

        for(let input of args) {

            let arg = input.split(' ');

            if(arg[0] === 'add')
                add(arg[1]);
            else if(arg[0] === 'remove')
                remove(arg[1]);
            else if(arg[0] === 'print')
                print(list);
        }
    }
})()
//solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);

solve(['add pesho', 'add gosho', 'add pesho', 'remove pesho','print']);



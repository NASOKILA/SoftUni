const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
        Task.find().then( tasks => {
            res.render('task/index', {
                'openTasks': tasks.filter(t => t.status === "Open"),
                'inProgressTasks': tasks.filter(t => t.status === "In Progress"),
                'finishedTasks': tasks.filter(t => t.status === "Finished")
            });
        });
	},

	createGet: (req, res) => {
		res.render('task/create');
	},

	createPost: (req, res) => {

        // vzimame si taska ot formata
        let task = req.body;

        // Ako ima prazvni poleta se vrushtame kum create viewto
        if(task.title === "")
        {
            res.render('task/create');
            return;
        }
        //Ako nqma prazni poleta seivame v bazata polucheniq task
        Task.create(task).then(task => {
            res.redirect('/');
        });
	},

	editGet: (req, res) => {
        //vzimame id-to
        let id = req.params.id;

        Task.findById(id).then(task => {

            if(!task)
            {
                // ako nqma takuv task se vrushtame v glavnata stranice
                res.redirect('/');
                return;
            }

            //prosto pokazvame viewto i mu podavame taska
            res.render('task/edit', task);

        });

    },

	editPost: (req, res) => {
        // vzimame id-to
        let id = req.params.id;

        //vzimame si novite stoinosti
        let taskChanged = req.body;

        if(taskChanged.title === "" || taskChanged.status === "")
		{
            res.render('task/edit', taskChanged);
            return;
		}

        Task.findByIdAndUpdate(id, taskChanged , {runValidators:true})
            .then( task => {
                res.redirect('/');
            });


    }
};
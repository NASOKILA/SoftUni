const Task = require('../models/Task');

module.exports = {

	index: (req, res) => {

    	Task.find().then(tasks => {

            res.render('task/index', {'tasks': tasks});
		});

    },

	createGet: (req, res) => {
        res.render('task/create');
    },

	createPost: (req, res) => {

		let task = req.body;

		if(task.title === "" || task.comments === "")
		{
            res.render('task/create',task);
            return;
		}

        Task.create(task).then(task => {
        	res.redirect('/');
		});
	},

	deleteGet: (req, res) => {

		let id = req.params.id;
        Task.findById(id).then(task => {
        	res.render('task/delete',task)

		});

	},

	deletePost: (req, res) => {

        let id = req.params.id;
        Task.findByIdAndRemove(id).then(task => {
            res.redirect('/');
        });

	}
};
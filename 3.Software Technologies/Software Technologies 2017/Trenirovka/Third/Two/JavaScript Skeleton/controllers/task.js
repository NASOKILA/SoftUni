const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {

		Task.find().then(tasks => {

			let openTasks = tasks.filter(t => t.status === 'Open');
			let inProgressTasks = tasks.filter(t => t.status === 'In Progress');
			let finishedTasks = tasks.filter(t => t.status === 'Finished');

			res.render('task/index',
				{
					openTasks: openTasks,
                    inProgressTasks: inProgressTasks,
					finishedTasks: finishedTasks
				});
		})

	},

	createGet: (req, res) => {
		res.render('task/create');
	},

	createPost: (req, res) => {

		let task = req.body;

		if(task.title === "" || task.status === "")
		{
            res.render('task/create');
            return;
		}

		Task.create(task).then(task => {
			res.redirect('/');
		})
	},

	editGet: (req, res) => {

		let id = req.params.id;

		Task.findById(id).then(task => {
			res.render('task/edit', task);
		})
	},
	editPost: (req, res) => {

		let id = req.params.id;
		let newTask = req.body;

		if(newTask.title === "" ||newTask.title === "")
		{
			res.render('task/edit', newTask);
			return;
		}

		Task.findByIdAndUpdate(id, newTask).then(task => {
			res.redirect('/');
		})


	}
};
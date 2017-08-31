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

		let task = req.body;

		if(task.title === "" ||task.status === "")
		{
			res.redirect('/create');
		}
		Task.create(task).then(
			res.redirect('/')
		);
	},

	editGet: (req, res) => {

		let id = req.params.id;

		Task.findById(id).then(task => {

			if(!task)
			{
				res.redirect('/');
			}

			res.render('task/edit', task)
		})
	},

	editPost: (req, res) => {

		let id = req.params.id;
		let taskChanged = req.body;

		if(taskChanged.title === "" || taskChanged.status === "")
		{
			res.redirect('/');
			return;
		}

		Task.findByIdAndUpdate(id, taskChanged).then(
				res.redirect('/')
		);

	}
};
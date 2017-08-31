const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        //TODO: Implement me...
		res.render('task/index', {'tasks': null});
    },
	createGet: (req, res) => {
        //TODO: Implement me...
	},
	createPost: (req, res) => {
        //TODO: Implement me...
	},
	deleteGet: (req, res) => {
        //TODO: Implement me...
	},
	deletePost: (req, res) => {
        //TODO: Implement me...
	}
};
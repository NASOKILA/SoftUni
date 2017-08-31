const mongoose = require('mongoose');

let taskSchema = mongoose.Schema({
	// TODO: Implement me...
});

let Task = mongoose.model('Task', taskSchema);

module.exports = Task;
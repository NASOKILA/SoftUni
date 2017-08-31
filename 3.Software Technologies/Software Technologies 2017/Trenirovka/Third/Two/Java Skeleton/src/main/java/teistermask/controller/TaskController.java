package teistermask.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.bindingModel.TaskBindingModel;
import teistermask.repository.TaskRepository;

@Controller
public class TaskController {
	private final TaskRepository taskRepository;

	@Autowired
	public TaskController(TaskRepository taskRepository) {
		this.taskRepository = taskRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		// TODO: Implement me...
	}

	@GetMapping("/create")
	public String create(Model model) {
		// TODO: Implement me...
	}

	@PostMapping("/create")
	public String createProcess(Model model, TaskBindingModel taskBindingModel) {
		// TODO: Implement me...
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
		// TODO: Implement me...
	}

	@PostMapping("/edit/{id}")
	public String editProcess(@PathVariable int id, TaskBindingModel taskBindingModel) {
		// TODO: Implement me...
	}
}

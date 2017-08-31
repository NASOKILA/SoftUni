package todolist.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import todolist.bindingModel.TaskBindingModel;
import todolist.entity.Task;
import todolist.repository.TaskRepository;

import java.util.List;

@Controller
public class TaskController {
    private final TaskRepository taskRepository;

    @Autowired
    public TaskController(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        //TODO:Implement me...

        model.addAttribute("tasks", null);
        model.addAttribute("view", "task/index");

        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        //TODO:Implement me...

        return null;
    }

    @PostMapping("/create")
    public String createProcess(Model model, TaskBindingModel taskBindingModel) {
        //TODO:Implement me...

        return null;
    }

    @GetMapping("/delete/{id}")
    public String delete(Model model, @PathVariable int id) {
        //TODO:Implement me...

        return null;
    }

    @PostMapping("/delete/{id}")
    public String deleteProcess(Model model, @PathVariable int id) {
        //TODO:Implement me...

        return null;
    }
}

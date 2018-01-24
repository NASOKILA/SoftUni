package imdb.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import imdb.bindingModel.FilmBindingModel;
import imdb.entity.Film;
import imdb.repository.FilmRepository;

import java.util.List;

@Controller
public class FilmController {

	private final FilmRepository filmRepository;

	@Autowired
	public FilmController(FilmRepository filmRepository) {
		this.filmRepository = filmRepository;

	}

	@GetMapping("/")
	public String index(Model model) {

		List<Film> films = filmRepository.findAll();

		model.addAttribute("films", films);
		model.addAttribute("view", "film/index");
		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {

		model.addAttribute("view", "film/create");
		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, FilmBindingModel filmBindingModel) {

		Film film = new Film();

		film.setName(filmBindingModel.getName());
		film.setGenre(filmBindingModel.getGenre());
		film.setDirector(filmBindingModel.getDirector());
		film.setYear(filmBindingModel.getYear());

		if(film.getName().equals("") || film.getGenre().equals("")
				|| film.getDirector().equals("") || film.getYear().equals(0))
		{
			return "redirect:/create";
		}

		filmRepository.save(film);
		filmRepository.flush();
		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {

		Film film = filmRepository.findOne(id);

		if(film == null)
		{
			return "redirect:/";
		}
		model.addAttribute("film", film);
		model.addAttribute("view", "film/edit");
		return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, FilmBindingModel filmBindingModel) {

		Film film = filmRepository.findOne(id);

		if(film == null)
		{
			return "redirect:/";
		}

		if(filmBindingModel.getName().equals("") || filmBindingModel.getGenre().equals("")
				|| filmBindingModel.getDirector().equals("") || filmBindingModel.getYear().equals(0))
		{
			model.addAttribute("film", film);
			model.addAttribute("view", "film/edit");
			return "base-layout";
		}


		film.setName(filmBindingModel.getName());
		film.setGenre(filmBindingModel.getGenre());
		film.setDirector(filmBindingModel.getDirector());
		film.setYear(filmBindingModel.getYear());

		filmRepository.flush();

		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		Film film = filmRepository.findOne(id);

		if(film == null)
		{
			return "redirect:/";
		}

		model.addAttribute("film", film);
		model.addAttribute("view", "film/delete");
		return "base-layout";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id) {

		Film film = filmRepository.findOne(id);

		if(film == null)
		{
			return "redirect:/";
		}

		filmRepository.delete(film);
		filmRepository.flush();

		return "redirect:/";
	}
}

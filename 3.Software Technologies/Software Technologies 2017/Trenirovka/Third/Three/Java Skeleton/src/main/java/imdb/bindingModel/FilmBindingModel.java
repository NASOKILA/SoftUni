package imdb.bindingModel;

import javax.persistence.Column;

public class FilmBindingModel {

    @Column(nullable = true)
    private String Name;

    @Column(nullable = true)
    private String Genre;

    @Column(nullable = true)
    private String Director;

    @Column(nullable = true)
    private Integer Year;

    public FilmBindingModel() {
    }

    public FilmBindingModel(String name, String genre, String director, Integer year) {
        Name = name;
        Genre = genre;
        Director = director;
        Year = year;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getGenre() {
        return Genre;
    }

    public void setGenre(String genre) {
        Genre = genre;
    }

    public String getDirector() {
        return Director;
    }

    public void setDirector(String director) {
        Director = director;
    }

    public Integer getYear() {
        return Year;
    }

    public void setYear(Integer year) {
        Year = year;
    }
}

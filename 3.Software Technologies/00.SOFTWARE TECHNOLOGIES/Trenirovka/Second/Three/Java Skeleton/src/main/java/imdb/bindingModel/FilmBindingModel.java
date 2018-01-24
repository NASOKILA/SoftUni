package imdb.bindingModel;

import javax.persistence.Column;

public class FilmBindingModel {

    @Column(nullable = true)
    private String name;

    @Column(nullable = true)
    private String genre;

    @Column(nullable = true)
    private String director;

    @Column(nullable = true)
    private Integer year;

    public FilmBindingModel() {
    }

    public FilmBindingModel(String name, String genre, String director, Integer year) {
        this.name = name;
        this.genre = genre;
        this.director = director;
        this.year = year;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getGenre() {
        return genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    public String getDirector() {
        return director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    public Integer getYear() {
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}

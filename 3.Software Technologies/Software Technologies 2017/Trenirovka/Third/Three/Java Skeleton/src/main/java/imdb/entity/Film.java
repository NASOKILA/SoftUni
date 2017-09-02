package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer Id;

    @Column(nullable = true)
    private String Name;

    @Column(nullable = true)
    private String Genre;

    @Column(nullable = true)
    private String Director;

    @Column(nullable = true)
    private Integer Year;

    public Film() {
    }

    public Film(String name, String genre, String director, Integer year) {
        Name = name;
        Genre = genre;
        Director = director;
        Year = year;
    }

    public Integer getId() {
        return Id;
    }

    public void setId(Integer id) {
        Id = id;
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

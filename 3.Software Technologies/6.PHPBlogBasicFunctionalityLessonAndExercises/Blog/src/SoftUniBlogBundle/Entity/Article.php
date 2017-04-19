<?php

namespace SoftUniBlogBundle\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints as Assert;

/**
 * Article
 *
 * @ORM\Table(name="articles")
 * @ORM\Entity(repositoryClass="SoftUniBlogBundle\Repository\ArticleRepository")
 */
class Article
{
    /**
     * @var int
     *
     * @ORM\Column(name="id", type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     */
    private $id;


    /**
     * @var string
     * @Assert\NotBlank()
     * @ORM\Column(name="Title", type="string", length=255)
     */
    private $title;
//sus assert\NotBlank() kazvame che trqbva da Ne e prazno, V SLUCHAQ TRQBVA ZAGLAVIETO DA NE E PRAZNO
//Sega proverkata v articleController za dali dannite sa validni vuv ifa na funkciqta createArticle NQMA DA MINE
// Sledovatelno shte ni vurne na stranicata article create
// S KONTROL I SPACE VIJDAME KAKVO MOJE DA PRAVI ASSERT


    /**
     * @var string
     * @Assert\NotBlank()
     * @ORM\Column(name="Content", type="text")
     */
    private $content;
//sus assert\NotBlank() kazvame che trqbva da Ne e prazno, V SLUCHAQ TRQBVA KONTENTA DA NE E PRAZEN
//Sega proverkata v articleController za dali dannite sa validni vuv ifa na funkciqta createArticle NQMA DA MINE
// Sledovatelno shte ni vurne na stranicata article create
// S KONTROL I SPACE VIJDAME KAKVO MOJE DA PRAVI ASSERT

    /**
     * @var \DateTime
     *
     * @ORM\Column(name="dateAdded", type="datetime")
     */
    private $dateAdded;


    // TRQBVA DA SI NAPRAVIM SUMMARITO SUS BUTONCHETATA:

    /**
     * @var string
     * */
    private $summary;


    /**
     * @var int
     * @ORM\Column(name="authorId", type="integer")
     * */
    private $authorId;

    /**
     * @var User
     * @ORM\ManyToOne(targetEntity="SoftUniBlogBundle\Entity\User", inversedBy="articles")
     * @ORM\JoinColumn(name="authorId", referencedColumnName="id")
     *
     */
    private $author;

    /**
     * @return \SoftUniBlogBundle\Entity\User
     */
    public function getAuthor(){
        return $this->author;
    }


    /**
     * @param User $author
     * @return Article
     */
    public function setAuthor(User $author = null){
        $this->author = $author;
        return $this;
        //SETVAME AVTORA NA TOVA KOETO NI SEE PODALO I POSLE VRUSHTAME OBEKTA
    }







    /**
     * @return int
     */
    public function getAuthorId(){

        return $this->authorId;
    }

    /**
     * @param $authorId
     * @return Article
     */
    public function setAuthorId($authorId){
        $this->authorId = $authorId;
        return $this;
        //SETVAME AVTORA NA TOVA KOETO NI SEE PODALO I POSLE VRUSHTAME OBEKTA
    }

    /**
     * @return string
     * */
    public function getSummary(){
    // ZA DA SE PODSIGURIM CHE VINAGI SHTE IMAME SUMMARY PROVERQVAME DALI IMA TAKOVA,
        // AKO NQMA, IZVIKVAME set METODA OT DOLO !!!
        if($this->summary === null){
            // == sravnqva po stoinost a === sravnqva po stoinost i po tip !!!
            // nie iskame da e null po stoinost i po tip takache slagame ===
            $this->setSummary();
        }
        return $this->summary;
    }

    /**
     * @return string
     * */
    public function setSummary(){

        $this->summary = substr($this->getContent(), 0 , strlen($this->getContent()) /2) . "...";
        // vzimame ot nula do polovinata na duljinata na kontenta i otzat slagame tochki

    }

    /**
     * Get id
     *
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Set title
     *
     * @param string $title
     *
     * @return Article
     */
    public function setTitle($title)
    {
        $this->title = $title;

        return $this;
        //SETVAME AVTORA NA TOVA KOETO NI SEE PODALO I POSLE VRUSHTAME OBEKTA
    }

    /**
     * Get title
     *
     * @return string
     */
    public function getTitle()
    {
        return $this->title;
    }

    /**
     * Set content
     *
     * @param string $content
     *
     * @return Article
     */
    public function setContent($content)
    {
        $this->content = $content;

        return $this;
        //SETVAME AVTORA NA TOVA KOETO NI SEE PODALO I POSLE VRUSHTAME OBEKTA
    }

    /**
     * Get content
     *
     * @return string
     */
    public function getContent()
    {
        return $this->content;
    }

    /**
     * Set dateAdded
     *
     * @param \DateTime $dateAdded
     *
     * @return Article
     */
    public function setDateAdded($dateAdded)
    {
        $this->dateAdded = $dateAdded;

        return $this;
        //SETVAME AVTORA NA TOVA KOETO NI SEE PODALO I POSLE VRUSHTAME OBEKTA
    }


    public function __construct(){
        $this->dateAdded = new \DateTime('now');
        //SETVAME DADATA NA TAZI KOQTO E V MOMENTA !
    }


    /**
     * Get dateAdded
     *
     * @return \DateTime
     */
    public function getDateAdded()
    {
        return $this->dateAdded;
    }
}


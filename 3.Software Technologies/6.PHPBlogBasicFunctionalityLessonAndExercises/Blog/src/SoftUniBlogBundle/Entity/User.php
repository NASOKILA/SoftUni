<?php

namespace SoftUniBlogBundle\Entity;

use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Security\Core\User\UserInterface;

/**
 * User
 *
 * @ORM\Table(name="users")
 * @ORM\Entity(repositoryClass="SoftUniBlogBundle\Repository\UserRepository")
 */
class User implements UserInterface
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
     *
     * @ORM\Column(name="email", type="string", length=100, unique=true)
     */
    private $email;

    /**
     * @var string
     *
     * @ORM\Column(name="fullName", type="string", length=255)
     */
    private $fullName;

    /**
     * @var string
     *
     * @ORM\Column(name="password", type="string", length=255)
     */
    private $password;


    /**
     * @var ArrayCollection
     * @ORM\OneToMany(targetEntity="SoftUniBlogBundle\Entity\Article", mappedBy="author")
     */
    private $articles; //TOVA E MASIV I SHTE DURGI VSICHKI POSTOVE NA TOZI USER
    //I SUS ONETOMANY VRUZKA EDIN AVTOR MOJE DA IMA MNOGO STATII !
    // NO VSQKA STATIQ MOJE DA IMA SAMO EDIN AVTOR





    /*
    CELTA NA VSQKO NESHTO E VSEKI USER DA MOJE DA SI TRIE SAMO SOBTVENITE ARTIKULI
    I DA IMAME ADMIN KOITO DA MOJE DA TRIE VSICHKI ARTIKULI
        TRQBVA DA SUZDADEM VRUZKA MANYTOMANY
        @var ArrayCollection kazvame che e masiv
        S ostanaloto opisvame che userite imat mnogo na
        broi roli i rolite imat mnogo na broi usery
    */

    /**
     * @var ArrayCollection
     * @ORM\ManyToMany(targetEntity="SoftUniBlogBundle\Entity\Role")
     * @ORM\JoinTable(name="users_roles",
     *     joinColumns={@ORM\JoinColumn(name="user_id", referencedColumnName="id")},
     *     inverseJoinColumns={@ORM\JoinColumn(name="role_id", referencedColumnName="id")})
     */
    private $roles;
//KUM USER ROLES SE PAZI SMO KOI USER KUM KOQ ROLQ E !!!


    /**
     * @return ArrayCollection
     */
    public function getArticles(){
        return $this->articles;
    }

    /**
     * @param Article $article
     * @return User
     */
    public function addPost(Article $article){
        $this->articles[] = $article;
        // DOBAVQME POST VUV SAMITE STATII T.E. DOBAVQ NOV ARTICLE KUM MASIVA !
        return $this;
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
     * Set email
     *
     * @param string $email
     *
     * @return User
     */
    public function setEmail($email)
    {
        $this->email = $email;

        return $this;
    }

    /**
     * Get email
     *
     * @return string
     */
    public function getEmail()
    {
        return $this->email;
    }

    /**
     * Set fullName
     *
     * @param string $fullName
     *
     * @return User
     */
    public function setFullName($fullName)
    {
        $this->fullName = $fullName;

        return $this;
    }

    /**
     * Get fullName
     *
     * @return string
     */
    public function getFullName()
    {
        return $this->fullName;
    }

    /**
     * Set password
     *
     * @param string $password
     *
     * @return User
     */
    public function setPassword($password)
    {
        $this->password = $password;

        return $this;
    }

    /**
     * Get password
     *
     * @return string
     */
    public function getPassword()
    {
        return $this->password;
    }

    /**
     * Returns the roles granted to the user.
     *
     * <code>
     * public function getRoles()
     * {
     *     return array('ROLE_USER');
     * }
     * </code>
     *
     * Alternatively, the roles might be stored on a ``roles`` property,
     * and populated in any number of different ways when the user object
     * is created.
     *
     * @return (Role|string)[] The user roles
     */
    public function getRoles()
    {
        // iskame da vurnem vsichkite roli kato masiv zatova generirame roleString

        $stringRole = [];
        foreach ($this->roles as $role)
        {
            //kazvame che rolqta e ot klas role
            /** @var @role Role*/
            $stringRole[] = $role->getRole();
            // izvikvame metoda klas role
        }

        return $stringRole;
    }

    /**
     * Returns the salt that was originally used to encode the password.
     *
     * This can return null if the password was not encoded using a salt.
     *
     * @return string|null The salt
     */
    public function getSalt()
    {
        return null;
    }

    /**
     * Returns the username used to authenticate the user.
     *
     * @return string The username
     */
    public function getUsername()
    {
        return $this->email;
    }

    /**
     * Removes sensitive data from the user.
     *
     * This is important if, at any given point, sensitive information like
     * the plain-text password is stored on this object.
     */
    public function eraseCredentials()
    {
        // TODO: Implement eraseCredentials() method.
    }

    public function addRole($role)
    {
        // KAZVAME CHE ZA VSEKI USER MOJEM DA GO DOBAVQME KUM NOVA ROLQ
        $this->roles[] = $role;
        return $this;
    }

    /*Konstrukturite sa funkcii koito se izvikvat vseki put kogato
      suzdadem nova instanciq na daden obekt

      V PHP NE MOJEM DA IMAME DVA METODA S EDNI I SUSHTI IMENA V EDIN I SUSHTI FAIL
       ZASHTOTO SHTE GRUMNE.
   */

    public function __construct()
    {
        $this->articles = new ArrayCollection();
        $this->roles = new ArrayCollection();
        // za vseki user inicializirame artikulite t.e. Array Collection
    }


    /*TRQBVA DA NAPRAVIM TAKA CHE EDIN USER DA MOJE DA EDITVA I TRIE
      SAMO NEGOVITE SI STATII A ADMINA DA TRIE VSICHKI ! */

    /**
     * @param $article
     * @return bool
     */
    public function isAuthor($article){
        // slagame tuk edna helper funkciq: DALI TOZI USER E AVTOR NA TOZI ARTIKUL ?

        return $article->getAuthorId() == $this->getId();

    }

    public function isAdmin(){
        return in_array("ROLE_ADMIN", $this->getRoles());
        // THE FUNCTION in_array() IN PHP IS LIKE Contains() IN C#
        // IN HERE WE CHECK IF THE COLECTION ARRAYCOLLECTION SUDURJA ROLE_ADMIN I AKO GO IMA NI VRUSHTA TRUE!
    }


    function __toString()
    {
        return $this->fullName;
    }
}


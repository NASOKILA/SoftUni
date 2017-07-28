<?php

namespace SoftUniBlogBundle\Controller;

use Doctrine\ORM\Mapping\Cache;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Method;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use SoftUniBlogBundle\Entity\Article;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;

class HomeController extends Controller
{
    /**
     * @Route("/", name="blog_index")
     * @Method("GET")
     */
    public function indexAction()
    {
        // Trqbva da bruknem v bazata ot danni i da izvadim vsichki statii ot tam:
            $articles = $this->getDoctrine()
                ->getRepository(Article::class)
                ->findAll();


        //Vrushtame si indexa
        return $this->render('blog/index.html.twig',
            ['articles' => $articles]);
    }
}

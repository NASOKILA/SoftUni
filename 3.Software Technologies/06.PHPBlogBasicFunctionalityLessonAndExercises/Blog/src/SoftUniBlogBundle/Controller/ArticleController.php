<?php

namespace SoftUniBlogBundle\Controller;

use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Security;
use SoftUniBlogBundle\Entity\Article;
use SoftUniBlogBundle\Form\ArticleType;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;


class ArticleController extends Controller
{
    /**
     * @param Request $request
     * @Route("article/create", name="article_create")
     * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function createArticle(Request $request){
        // SHTE SE IZPULNI AKO PUTQ E .../article/create , AKO USERA E LOGNAT
        // INACHE NQMA KAK DA VLEZE TUK!

        // IMAME 5 IMPORTNATI KLASA : ZA ZAQVKATA,ZA SAMIQ KONTOLER,
        // ZA Entity/Article, ZA Route I ZA Security
        $article = new Article();

        $form = $this->createForm(ArticleType::class, $article);
        //slagame $form da e = na nova forma ot tip ArticleType ot koqto rezultata se zapisva
        // v promenlivata $article


        // PREDI DA ZNAEM DALI FORMAta e sUBMITNATA I VLIDNA TRQBVA DA OBRABOTIM ZAQVKATA
        $form->handleRequest($request);





        if($form->isSubmitted() && $form->isValid())
        {
           // setvame avtora da e uzera:
            $article->setAuthor($this->getUser());
            $em = $this->getDoctrine()->getManager(); // vzimame entity manigera
            $em->persist($article); // s tozi menidjer mojem da zapishem artikula
            $em->flush();  // S flush() tezi promeni se izprashtat kum bazata danni !

            //sega trqbva da vurnem usera obratno kum index-a
            return $this->redirectToRoute('blog_index');

        }

            //SEGA VRUSHTAME ARTICLE CREATE VIEW-to
            return $this->render('article/create.html.twig',
                array('form' => $form->createView()));
            //kato parametri na tova view podava edin asociativen masiv s kluch 'form' i stoinost form create view

    }


    /**
     * @param integer $id
     * @Route("article/{id}", name="article_view")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    // tuk e sushtoto kato gore samo deto sochi article/id i se kazva article_view i vrushta id koeto einteger
    // mahame securitto zashtoto iskame vsichki da mogat da vijdat tova + tova te veche sa lognati
    public function viewArticle($id){
        // tuk trqbva da napravim dve neshta: da bruknem v bazata danni i da izvadim statiqta i dannite ot neq
        // vtoro: da vurnem view na usera v koeto stoi samata statiq !!!

        $article = $this->getDoctrine()->getRepository(article::class)->find($id);
        // vmesto findAll() mu davame samo find() i id-to vutre v nego.


        //SEGA TRQBVA DA VURNEM TOVA VIEW NA USERA:

        if($article == null)
        { // ako nqma takuv article ni vrushta kum blog_index
            return $this->redirectToRoute("blog_index");
        }

        return $this->render('article/article.html.twig', array('article' => $article));
        // pokazvame vieto koeto tokushto napravihme i kato parametur mu davame samata statiq koqto drupnahme ot bazata!

    }


    /**
     * @Route("/article/edit/{id}", name="article_edit")
     * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
     */

    /*
        @Route("/article/edit/{id}", name="article_edit")IMETO NA TOZI ROUT E article_edit
        SUS @Security kazvame che trqbva da sme lognati inache nqma da stane
    */
    public function editArticle($id, Request $request){
        // s $id kazvame koit ochno artikul iskame da editvame
        // Za da suzdadem forma ni trqbva Request !!!
        //OT REQUESTA NIE PRAVIM FORMATA I DANNITE KOITO SE IZPRASHTAT OT USERA!

        $article = $this->getDoctrine()->getRepository(Article::class)->find($id);
        // taka vzimame artikula ot bazata, s Article::class kazvame che e ot klasa Article t.e. dannite ot tip Article


        if($article == null)
        { // ako nqma takuv article ni vrushta kum blog_index
            return $this->redirectToRoute("blog_index");
        }





        // AKO NQKOI POISKA DA EDITNE STATIQ TOI TRQBVA DA E NEIN AVTOR:
        $user = $this->getUser(); // s getUser() vzimame tekushtiq user

        if(!$user->isAuthor($article) && !$user->isAdmin()) // ako usera ne e avtor na tekushtiq article
        {
            return $this->redirectToRoute("blog_index"); // vrushtame sushtoto neshto t.e. blog_index
            // i ako usera ne e admin vrushtame sushtoto !
        }




        $form = $this->createForm(ArticleType::class, $article);
        // suzdavame si formata ot tip ArticleType koito veche go imame vuv form
        // I KAZVAME CHE ISKAME DA UPDATENEM $article


        $form->handleRequest($request);
        // TUK KAZVAME: AKO USERA E IZPRATIL NESHTO OPITAI DA OBRABOTISH NEGOVITE DANNI !


        if($form->isSubmitted() && $form->isValid()){
            // AKO FORMATA E SUBMITNATA I VALIDNA
            //VZIMAME DANNITE NA ARTIKULA
            $data = $this->getDoctrine()->getManager(); // vzimame menidjera
            $data->persist($article); // zapazvame artikula
            $data->flush(); // izprashtame promenite kum bazata


            return $this->redirectToRoute('article_view',['id' => $article->getId()]);
            //AKO VSICHKO E NARED REDIREKTVAME KUM ARTICLE_VIEW I ZGLOBQVAME NOVIQ ARTIKUL
            //KAKTO SME OPISALI V SYMFONI-to GORE, TRQBVA DA VURNEM ARTICLE_VIEW NO
    //SME PODALI I PARAMETUR $id KUM FUNKCIQTA I TRQBVA DA GO PODADEM PRI RETURN T.E. EDITVANETO !!!!!
        }

        // ako vsichko e ok trqbva da vurnem html koito da editva nashiq artikul:
        return $this->render('article/edit.html.twig',
            ['article' => $article,
             'form' => $form->createView()
            ]);
        // TRQBVA DA PODADEM I FORMATA I MU DAVAME CREATEVIEW() INACHE NQMA DA STANE

    }


    /**
     * @Route("/article/delete/{id}", name="article_delete")
     * @Security("is_granted('IS_AUTHENTICATED_FULLY')")
     * @param $id
     * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
     */

    public function deleteArticle($id){
        $article = $this->getDoctrine()->getRepository(Article::class)->find($id);

        // trqbva da proverim dali takuv artikul sushteestvuva
        if($article == null)
        {
            return $this->redirectToRoute('blog_index');
        }

        $user = $this->getUser();

        if(!$user->isAdmin() && !$user->isAuthor($article))
        {
            return $this->redirectToRoute("blog_index");
        }

        return $this->render('article/delete.html.twig', [
                'id' => $id
            ]);// ako ima znachi vrushtame tazi stranica
    }


    /**
     * @Route("/article/confirm/{id}", name="article_confirm_delete")
     * @param $id
     * @return \Symfony\Component\HttpFoundation\RedirectResponse|\Symfony\Component\HttpFoundation\Response
     */

    public function confirmDelete($id){
        $article = $this->getDoctrine()->getRepository(Article::class)->find($id);

        if($article != null){

            // Ako ima takuv article go triem !
            $data = $this->getDoctrine()->getManager();
            $data->remove($article);
            $data->flush();
        }

        // i nakraq se vrushtame na blog_index nezavisimo dali sme go iztrili ili ne !
        return $this->redirectToRoute('blog_index');

    }
}

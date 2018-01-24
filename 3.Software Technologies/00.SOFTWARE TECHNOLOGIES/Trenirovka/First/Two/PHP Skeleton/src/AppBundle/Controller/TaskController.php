<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $tasksRepo = $this
            ->getDoctrine()
            ->getRepository(Task::class);

        $openTasks = $tasksRepo->findBy(['status' => 'Open']);
        $inProgressTasks = $tasksRepo->findBy(['status' => 'In progress']);
        $finishedTasks = $tasksRepo->findBy(['status' => 'Finished']);


        return $this->render('task/index.html.twig',
            [
                'openTasks' => $openTasks,
                'inProgressTasks' => $inProgressTasks,
                'finishedTasks' => $finishedTasks
            ]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $task = new Task();

        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);

        if($form->isSubmitted() || $form->isValid())
        {

            $em = $this->getDoctrine()->getManager();
            $em->persist($task);
            $em->flush();

            return $this->redirectToRoute("index");
        }
        return $this->render('task/create.html.twig', ['form' => $form->createView()]);
    }

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $task = $this->getDoctrine()->getRepository(Task::class)->find($id);

        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);

        if($form->isSubmitted() && $form->isValid())
        {

            if($task->getTitle() === null || $task->getStatus() === null)
            {
                return $this->redirectToRoute("index");
            }

            $em = $this->getDoctrine()->getManager();
            $em->merge($task);
            $em->flush();

            return $this->redirectToRoute("index");
        }

        return $this->render(':task:edit.html.twig', [
            'form' => $form->createView(),
            'task' => $task
        ]);
    }
}

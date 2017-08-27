package Lesson1;

/**
 * Created by Looky on 03.07.2017.
 */
public class Main {
    public static void main(String[] args) {
        Queue queue = new Queue(5);
        for (int i = 0; i < 4; i++)
        {
            queue.enqueue(i);
        }

        for (int i = 0; i < 4; i++)
        {
            System.out.println(queue.dequeue());
        }

        for (int i = 0; i < 2; i++)
        {
            queue.enqueue(i);
        }
        System.out.println(queue.dequeue());
        for (int i = 2; i < 4; i++)
        {
            queue.enqueue(i);
        }
        System.out.println(queue.dequeue());
        System.out.println(queue.dequeue());
        System.out.println(queue.dequeue());
    }
}

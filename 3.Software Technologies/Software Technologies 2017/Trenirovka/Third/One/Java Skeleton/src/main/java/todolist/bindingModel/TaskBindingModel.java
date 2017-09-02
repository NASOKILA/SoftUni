package todolist.bindingModel;

import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

public class TaskBindingModel {


    private String Title;

    private String Comments;

    public TaskBindingModel() {
    }

    public TaskBindingModel(String title, String comments) {
        Title = title;
        Comments = comments;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public String getComments() {
        return Comments;
    }

    public void setComments(String comments) {
        Comments = comments;
    }
}

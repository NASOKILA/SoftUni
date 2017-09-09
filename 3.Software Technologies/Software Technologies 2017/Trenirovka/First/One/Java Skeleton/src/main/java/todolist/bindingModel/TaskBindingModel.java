package todolist.bindingModel;

import javax.persistence.Column;

public class TaskBindingModel {

    private String title;

    private String comments;

    public TaskBindingModel(String title, String comments) {
        this.title = title;
        this.comments = comments;
    }

    public TaskBindingModel() {
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getComments() {
        return comments;
    }

    public void setComments(String comments) {
        this.comments = comments;
    }
}
package shoppinglist.bindingModel;

import javax.persistence.Column;

public class ProductBindingModel {

    @Column(nullable = true)
    private Integer priority;

    @Column(nullable = true)
    private String name;

    @Column(nullable = true)
    private String quantity;

    @Column(nullable = true)
    private String status;

    public ProductBindingModel() {
    }

    public ProductBindingModel(Integer priority, String name, String quantity, String status) {
        this.priority = priority;
        this.name = name;
        this.quantity = quantity;
        this.status = status;
    }

    public Integer getPriority() {
        return priority;
    }

    public void setPriority(Integer priority) {
        this.priority = priority;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getQuantity() {
        return quantity;
    }

    public void setQuantity(String quantity) {
        this.quantity = quantity;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}

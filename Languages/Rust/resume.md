You would use lifetimes with &str or other borrowed references when:

You want to avoid copying or allocating data unnecessarily.


The data you're referencing already exists elsewhere and you don't want to take ownership.

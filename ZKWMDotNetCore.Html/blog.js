
const tblBlog = "blogs";
let lst = [];

readBlog();
//createBlog("Test 4", "Test 5","Test 6");
//updateBlog("6ccb7f15-285d-44cc-ad8d-3179b23c11c4","Test title","Test author","Test content");
//deleteBlog("4d0e13d4-3a85-4ad9-965e-7397158d65df");

function readBlog(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);
}

function createBlog(title, author, content){
    read();

    const requestModel = {
        id : uuidv4(),
        title : title,
        author : author,
        content : content
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("blogs",jsonBlog);
}

function updateBlog(id, title, author, content){
    read();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);
    if(items.length == 0){
        console.log("no data found.");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x=> x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("blogs",jsonBlog);
}

function deleteBlog(id){
    read();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    console.log(items.length);
    if(items.length == 0){
        console.log("no data found.");
        return;
    }
    
    lst = lst.filter(x=> x.id !== id);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem("blogs",jsonBlog);
}

function read(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
}

function uuidv4() {
    return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}
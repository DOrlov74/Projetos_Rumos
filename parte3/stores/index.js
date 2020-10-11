import {stores, stocks} from '../data/index.js';

let viewMode=true;  //table mode
let newItem=false;  //add new store mode

const fillStores=(stores)=>{
    const table=document.querySelector('.table-container');
    const card=document.querySelector('.cards-container');
    if(viewMode){
        clearTable();
        stores.forEach(element => {
            table.classList.remove('hidden');
            card.classList.add('hidden');
            card.classList.remove('columns');
            addStoreToTable(element);
        })
    }else{
        clearCards();
        stores.forEach(element => {
            table.classList.add('hidden');
            card.classList.remove('hidden');
            card.classList.add('columns');
            addStoreToCard(element);
        })
    }
}

const addStoreToTable=(store)=>{
    const row=document.createElement('tr');
    row.classList.add('data-row');
    const idCell=document.createElement('td');
    idCell.classList.add('id-cell');
    idCell.innerText=store.id;
    row.appendChild(idCell);
    const nameCell=document.createElement('td');
    nameCell.classList.add('name-cell');
    nameCell.innerText=store.name;
    row.appendChild(nameCell);
    const addressCell=document.createElement('td');
    addressCell.classList.add('address-cell');
    addressCell.innerText=store.address;
    row.appendChild(addressCell);
    const activeCell=document.createElement('td');
    activeCell.classList.add('active-cell');
    activeCell.innerText=store.active;
    row.appendChild(activeCell);
    const createdCell=document.createElement('td');
    createdCell.classList.add('created-cell');
    createdCell.innerText=store.dateCreated;
    row.appendChild(createdCell);
    const modifiedCell=document.createElement('td');
    modifiedCell.classList.add('modified-cell');
    modifiedCell.innerText=store.dateModified;
    row.appendChild(modifiedCell);
    const editCell=document.createElement('td');
    const editButton=document.createElement('div');
    editButton.classList.add('edit-button');
    editButton.classList.add('table-button-1');
    editCell.appendChild(editButton);
    editButton.addEventListener('click', editStoreInTable);
    row.appendChild(editCell);
    const deleteCell=document.createElement('td');
    const deleteButton=document.createElement('button');
    deleteButton.classList.add('delete');
    deleteCell.appendChild(deleteButton);
    deleteButton.addEventListener('click', removeStoreFromTable);
    row.appendChild(deleteCell);
    const content=document.querySelector('.table__content');
    const form=document.querySelector('.table__form');
    content.insertBefore(row, form);
}

const addStoreToCard=(store)=>{
    const container=document.querySelector('.cards-container');
    const cardTempl=document.querySelector('.card-container');
    const card=document.createElement('div');
    card.classList.add('card-container');
    card.classList.add('column');
    card.classList.add('is-half');
    card.classList.add('data-card');
    card.innerHTML=cardTempl.innerHTML;
    const col1=card.querySelector('.content__data__column-1');
    const col2=card.querySelector('.content__data__column-2');
    const idKeyDiv=document.createElement('div');
    idKeyDiv.classList.add('id-key');
    idKeyDiv.innerText='Id';
    const idValDiv=document.createElement('div');
    idValDiv.classList.add('id-val');
    idValDiv.innerText=store.id===undefined?'':store.id;
    col1.appendChild(idKeyDiv);
    col2.appendChild(idValDiv);
    const nameKeyDiv=document.createElement('div');
    nameKeyDiv.classList.add('name-key');
    nameKeyDiv.innerText='Store Name';
    const nameValDiv=document.createElement('div');
    nameValDiv.classList.add('name-val');
    nameValDiv.innerText=store.name===undefined?'':store.name;
    col1.appendChild(nameKeyDiv);
    col2.appendChild(nameValDiv);
    const addressKeyDiv=document.createElement('div');
    addressKeyDiv.classList.add('address-key');
    addressKeyDiv.innerText='Store Address';
    const addressValDiv=document.createElement('div');
    addressValDiv.classList.add('address-val');
    addressValDiv.innerText=store.address===undefined?'':store.address;
    col1.appendChild(addressKeyDiv);
    col2.appendChild(addressValDiv);
    const activeKeyDiv=document.createElement('div');
    activeKeyDiv.classList.add('active-key');
    activeKeyDiv.innerText='Active';
    const activeValDiv=document.createElement('div');
    activeValDiv.classList.add('active-val');
    activeValDiv.innerText=store.active===undefined?'':store.active;
    col1.appendChild(activeKeyDiv);
    col2.appendChild(activeValDiv);
    const createdKeyDiv=document.createElement('div');
    createdKeyDiv.classList.add('created-key');
    createdKeyDiv.innerText='Created at';
    const createdValDiv=document.createElement('div');
    createdValDiv.classList.add('created-val');
    createdValDiv.innerText=store.dateCreated===undefined?date:store.dateCreated;
    col1.appendChild(createdKeyDiv);
    col2.appendChild(createdValDiv);
    const modifiedKeyDiv=document.createElement('div');
    modifiedKeyDiv.classList.add('modified-key');
    modifiedKeyDiv.innerText='Modified at';
    const modifiedValDiv=document.createElement('div');
    modifiedValDiv.classList.add('modified-val');
    modifiedValDiv.innerText=store.dateModified===undefined?date:store.dateModified;
    col1.appendChild(modifiedKeyDiv);
    col2.appendChild(modifiedValDiv);
    const deleteButton=card.querySelector('.card__button-2');
    deleteButton.addEventListener('click', removeStoreCard);
    const editButton=card.querySelector('.card__button-1');
    editButton.addEventListener('click', editStoreCard);
    container.appendChild(card);
}

const submitStore=()=>{
    const idInput=document.querySelector('.id-input');
    const nameInput=document.querySelector('.name-input');
    const addressInput=document.querySelector('.address-input');
    const activeSelect=document.querySelector('.active-select');
    const createdInput=document.querySelector('.created-at-input');
    const modifiedInput=document.querySelector('.modified-at-input');
    const store={};
    store.id=idInput.value;
    store.name=nameInput.value;
    store.address=addressInput.value;
    store.active=activeSelect.value;
    store.dateCreated=createdInput.value;
    store.dateModified=modifiedInput.value;
    addStoreToTable(store);
}

const removeStoreFromTable=(e)=>{
    const store=e.target.parentNode.parentNode;
    store.remove();
}

const clearTable=()=>{
    const dataRows=document.querySelectorAll('.data-row');
    dataRows.forEach(element => {
        element.remove();
    });
}

const removeStoreCard=(e)=>{
    const card=e.target.parentNode.parentNode.parentNode;
    card.remove();
}

const clearCards=()=>{
    const dataCards=document.querySelectorAll('.data-card');
    dataCards.forEach(element => {
        element.remove();
    });
}

const editStoreInTable=(e)=>{
    const store=e.target.parentNode.parentNode;
    store.classList.add('table__form');
    const idCell=store.querySelector('.id-cell');
    const nameCell=store.querySelector('.name-cell');;
    const addressCell=store.querySelector('.address-cell');
    const activeCell=store.querySelector('.active-cell');
    const createdCell=store.querySelector('.created-cell');
    const modifiedCell=store.querySelector('.modified-cell');
    const editButton=store.querySelector('.table-button-1');
    editButton.classList.replace('edit-button', 'submit-button');
    editButton.removeEventListener('click', editStoreInTable);
    editButton.addEventListener('click', validateForm);
    const idInput=document.createElement('input');
    const idAtr = document.createAttribute("name");      
    idAtr.value = "id";                           
    idInput.setAttributeNode(idAtr);
    const reqIdAtr = document.createAttribute("required");
    idInput.setAttributeNode(reqIdAtr);
    idInput.classList.add('id-input');
    idInput.classList.add('input');
    idInput.value=idCell.innerText;
    idCell.innerText='';
    idCell.appendChild(idInput);
    const nameInput=document.createElement('input');
    const nameAtr = document.createAttribute("name");      
    nameAtr.value = "store-name";                           
    nameInput.setAttributeNode(nameAtr);
    const reqnameAtr = document.createAttribute("required");
    nameInput.setAttributeNode(reqnameAtr);
    nameInput.classList.add('name-input');
    nameInput.classList.add('input');
    nameInput.value=nameCell.innerText;
    nameCell.innerText='';
    nameCell.appendChild(nameInput);
    const addressInput=document.createElement('input');
    const addressAtr = document.createAttribute("name");      
    addressAtr.value = "address";                           
    addressInput.setAttributeNode(addressAtr);
    addressInput.classList.add('address-input');
    addressInput.classList.add('input');
    addressInput.value=addressCell.innerText;
    addressCell.innerText='';
    addressCell.appendChild(addressInput);
    const activeContainer=document.createElement('span');
    activeContainer.classList.add('select');
    const activeSelect=document.createElement('select');
    activeSelect.classList.add('active-select');
    activeSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    activeSelect.appendChild(trueOption);
    activeSelect.appendChild(falseOption);
    activeSelect.value=activeCell.innerText;
    activeCell.innerText='';
    activeContainer.appendChild(activeSelect);
    activeCell.appendChild(activeContainer);
    const createdInput=document.createElement('input');
    const createdAtr = document.createAttribute("name");      
    createdAtr.value = "created-at";                           
    createdInput.setAttributeNode(createdAtr);
    createdInput.classList.add('created-at-input');
    createdInput.classList.add('input');
    createdInput.value=createdCell.innerText;
    createdCell.innerText='';
    createdCell.appendChild(createdInput);
    const modifiedInput=document.createElement('input');
    const modifiedAtr = document.createAttribute("name");      
    modifiedAtr.value = "modified-at";                           
    modifiedInput.setAttributeNode(modifiedAtr);
    modifiedInput.classList.add('modified-at-input');
    modifiedInput.classList.add('input');
    modifiedInput.value=date;
    modifiedCell.innerText='';
    modifiedCell.appendChild(modifiedInput);
    const inputList=product.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const editStoreCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.add('card-form');
    const idDiv=card.querySelector('.id-val');
    const nameDiv=card.querySelector('.name-val');
    const addressDiv=card.querySelector('.address-val');
    const activeDiv=card.querySelector('.active-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__edit-button', 'card__save-button');
    editButton.removeEventListener('click', editStoreCard);
    editButton.addEventListener('click', validateForm);
    const idInput=document.createElement('input');
    const idAtr = document.createAttribute("name");      
    idAtr.value = "id";                           
    idInput.setAttributeNode(idAtr);
    const reqIdAtr = document.createAttribute("required");
    idInput.setAttributeNode(reqIdAtr);
    idInput.classList.add('id-input');
    idInput.classList.add('input');
    idInput.placeholder='id';
    idInput.value=idDiv.innerText;
    idDiv.innerText='';
    idDiv.appendChild(idInput);
    const nameInput=document.createElement('input');
    const nameAtr = document.createAttribute("name");      
    nameAtr.value = "store-name";                           
    nameInput.setAttributeNode(nameAtr);
    const reqNameAtr = document.createAttribute("required");
    nameInput.setAttributeNode(reqNameAtr);
    nameInput.classList.add('name-input');
    nameInput.classList.add('input');
    nameInput.placeholder='Store Name';
    nameInput.value=nameDiv.innerText;
    nameDiv.innerText='';
    nameDiv.appendChild(nameInput);
    const addressInput=document.createElement('input');
    const addressAtr = document.createAttribute("name");      
    addressAtr.value = "address";                           
    addressInput.setAttributeNode(addressAtr);
    addressInput.classList.add('address-input');
    addressInput.classList.add('input');
    addressInput.placeholder='Address';
    addressInput.value=addressDiv.innerText;
    addressDiv.innerText='';
    addressDiv.appendChild(addressInput);
    const activeSelect=document.createElement('select');
    activeSelect.classList.add('active-select');
    activeSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    activeSelect.appendChild(trueOption);
    activeSelect.appendChild(falseOption);
    if(activeDiv.innerText!=='')
    {
        activeSelect.value=activeDiv.innerText;
        activeDiv.innerText='';
    }else{
        activeSelect.options.selectedIndex=0;
    }
    activeDiv.appendChild(activeSelect);
    const createdInput=document.createElement('input');
    const createdAtr = document.createAttribute("name");      
    createdAtr.value = "created-at";                           
    createdInput.setAttributeNode(createdAtr);
    createdInput.classList.add('created-at-input');
    createdInput.classList.add('input');
    createdInput.value=createdDiv.innerText;
    createdDiv.innerText='';
    createdDiv.appendChild(createdInput);
    const modifiedInput=document.createElement('input');
    const modifiedAtr = document.createAttribute("name");      
    modifiedAtr.value = "modified-at";                           
    modifiedInput.setAttributeNode(modifiedAtr);
    modifiedInput.classList.add('modified-at-input');
    modifiedInput.classList.add('input');
    modifiedInput.value=date;
    modifiedDiv.innerText='';
    modifiedDiv.appendChild(modifiedInput);
    const inputList=card.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const saveStoreCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.remove('card-form');
    const idDiv=card.querySelector('.id-val');
    const nameDiv=card.querySelector('.name-val');
    const addressDiv=card.querySelector('.address-val');
    const activeDiv=card.querySelector('.active-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__save-button', 'card__edit-button');
    editButton.removeEventListener('click', validateForm);
    editButton.addEventListener('click', editStoreCard);
    const idInput=card.querySelector('.id-input');
    const nameInput=card.querySelector('.name-input');
    const addressInput=card.querySelector('.address-input');
    const activeSelect=card.querySelector('.active-select');
    const createdInput=card.querySelector('.created-at-input');
    const modifiedInput=card.querySelector('.modified-at-input');
    const store={};
    store.id=idInput.value;
    store.name=nameInput.value;
    store.address=addressInput.value;
    store.active=activeSelect.value;
    store.dateCreated=createdInput.value;
    store.dateModified=modifiedInput.value;
    idDiv.innerText=store.id;
    nameDiv.innerText=store.name;
    addressDiv.innerText=store.address;
    activeDiv.innerText=store.active;
    createdDiv.innerText=store.dateCreated;
    modifiedDiv.innerText=store.dateModified;
}

//  fill table with data
fillStores(stores);

//  add view-mode event listener
const tableModeButton=document.querySelector('.view-options__table');
tableModeButton.addEventListener('click', ()=>{
    if(!viewMode)
    {
        viewMode=true;
        fillStores(stores);
    }
})
const cardModeButton=document.querySelector('.view-options__card');
cardModeButton.addEventListener('click', ()=>{
    if(viewMode)
    {
        viewMode=false;
        fillStores(stores);
    }
})

//  fill placeholders with current date
const createdInput=document.querySelector('.created-at-input');
const modifiedInput=document.querySelector('.modified-at-input');
const today = new Date();
const date = today.getDate()+'-'+(today.getMonth()+1)+'-'+today.getFullYear();
createdInput.value=date;
modifiedInput.value=date;

//  Validate input method
const validateInput=(e)=>{
    const el=e.target;
    const name=el.name;
    let err=document.querySelector('.'+name+'__error');
        if(!el.checkValidity()){
            if(!err)
            {
                //input error message
                err=document.createElement('div');
                err.classList.add(name+'__error');
                err.classList.add('error-message');
                err.innerHTML='Field "'+name+'": '+el.validationMessage;
                const container=document.querySelector('.error-container');
                container.appendChild(err);
                el.classList.add('error');
            }else{
                err.innerHTML='Field "'+name+'": '+el.validationMessage;
            }
        }else{
            if(err){
                err.remove();
            }
            el.classList.remove('error');
        }
};

//  validate form method
const validateForm=(e)=>{
    const formRow=e.target.parentNode.parentNode;
    const inputList=formRow.querySelectorAll('.input');
    for(let i=0; i<inputList.length; ++i) {
        if(!inputList[i].checkValidity()){
            const name=inputList[i].name;
            let err=document.querySelector('.'+name+'__error');
            if(!err)
            {
                //input error message
                err=document.createElement('div');
                err.classList.add(name+'__error');
                err.classList.add('error-message');
                err.innerHTML='Field "'+name+'": '+inputList[i].validationMessage;
                let container=document.querySelector('.error-container');
                container.appendChild(err);
                inputList[i].classList.add('error');
            }else{
                err.innerHTML='Field "'+name+'": '+inputList[i].validationMessage;
            }
            return;
        }
    };
    if(viewMode){
        submitStore();
        if(newItem){
            const form=document.querySelector('form');
            form.reset();
            addButton.click();
            newItem=false;
        }else{
            formRow.remove();
        }
    }else{
        saveStoreCard(e);
    }
}

//  add store event listener
const addButton=document.querySelector('.add-store-button');
const form=document.querySelector('.table__form');
addButton.addEventListener('click', function(){
    if(viewMode)
    {
        form.classList.toggle('hidden');
        this.classList.toggle('hide-button');
        this.classList.toggle('add-store-button');
        const inputList=form.querySelectorAll('.input');
        inputList.forEach(element => {
            element.addEventListener('blur', validateInput);
        });
        newItem=true;
    }else{
        const emptyStore={ };
        addStoreToCard(emptyStore);
        const lastCard=document.querySelector('.cards-container').lastChild;
        const editButton=lastCard.querySelector('.card__button-1');
        editButton.click();
    }
});

//  submit new store form event listener
const submitButton=document.querySelector('.submit-button');
submitButton.addEventListener('click', validateForm);
import {products, families, sales, users, pos, stores} from '../data/index.js';

let viewMode=true;  //table mode
let newItem=false;  //add new product mode

const fillSales=(sales)=>{
    const table=document.querySelector('.table-container');
    const card=document.querySelector('.cards-container');
    if(viewMode){
        clearTable();
        sales.forEach(element => {
            table.classList.remove('hidden');
            card.classList.add('hidden');
            card.classList.remove('columns');
            addSaleToTable(element);
        })
    }else{
        clearCards();
        sales.forEach(element => {
            table.classList.add('hidden');
            card.classList.remove('hidden');
            card.classList.add('columns');
            addSaleToCard(element);
        })
    }
}

const addSaleToTable=(sale)=>{
    const row=document.createElement('tr');
    row.classList.add('data-row');
    const idCell=document.createElement('td');
    idCell.classList.add('id-cell');
    idCell.innerText=sale.id;
    row.appendChild(idCell);
    const numberCell=document.createElement('td');
    numberCell.classList.add('number-cell');
    numberCell.innerText=sale.saleDocNum;
    row.appendChild(numberCell);
    const storeCell=document.createElement('td');
    storeCell.classList.add('store-cell');
    storeCell.innerText=sale.store;
    row.appendChild(storeCell);
    const posCell=document.createElement('td');
    posCell.classList.add('pos-cell');
    posCell.innerText=sale.pos;
    row.appendChild(posCell);
    const userCell=document.createElement('td');
    userCell.classList.add('user-cell');
    userCell.innerText=sale.user;
    row.appendChild(userCell);
    const customerCell=document.createElement('td');
    customerCell.classList.add('customer-cell');
    customerCell.innerText=sale.customer;
    row.appendChild(customerCell);
    const payedCell=document.createElement('td');
    payedCell.classList.add('payed-cell');
    payedCell.innerText=sale.payed;
    row.appendChild(payedCell);
    const createdCell=document.createElement('td');
    createdCell.classList.add('created-cell');
    createdCell.innerText=sale.dateCreated;
    row.appendChild(createdCell);
    const modifiedCell=document.createElement('td');
    modifiedCell.classList.add('modified-cell');
    modifiedCell.innerText=sale.dateModified;
    row.appendChild(modifiedCell);
    const editCell=document.createElement('td');
    const editButton=document.createElement('div');
    editButton.classList.add('edit-button');
    editButton.classList.add('table-button-1');
    editCell.appendChild(editButton);
    editButton.addEventListener('click', editSaleInTable);
    row.appendChild(editCell);
    const deleteCell=document.createElement('td');
    const deleteButton=document.createElement('button');
    deleteButton.classList.add('delete');
    deleteCell.appendChild(deleteButton);
    deleteButton.addEventListener('click', removeSaleFromTable);
    row.appendChild(deleteCell);
    const content=document.querySelector('.table__content');
    const form=document.querySelector('.table__form');
    content.insertBefore(row, form);
}

const addSaleToCard=(sale)=>{
    const container=document.querySelector('.cards-container');
    const cardTempl=document.querySelector('.card-container');
    const card=document.createElement('div');
    card.classList.add('card-container');
    card.classList.add('column');
    card.classList.add('is-one-third');
    card.classList.add('data-card');
    card.innerHTML=cardTempl.innerHTML;
    const col1=card.querySelector('.content__data__column-1');
    const col2=card.querySelector('.content__data__column-2');
    const idKeyDiv=document.createElement('div');
    idKeyDiv.classList.add('id-key');
    idKeyDiv.innerText='Id';
    const idValDiv=document.createElement('div');
    idValDiv.classList.add('id-val');
    idValDiv.innerText=sale.id===undefined?'':sale.id;
    col1.appendChild(idKeyDiv);
    col2.appendChild(idValDiv);
    const numberKeyDiv=document.createElement('div');
    numberKeyDiv.classList.add('number-key');
    numberKeyDiv.innerText='Product Name';
    const numberValDiv=document.createElement('div');
    numberValDiv.classList.add('number-val');
    numberValDiv.innerText=sale.saleDocNum===undefined?'':sale.saleDocNum;
    col1.appendChild(numberKeyDiv);
    col2.appendChild(numberValDiv);
    const storeKeyDiv=document.createElement('div');
    storeKeyDiv.classList.add('store-key');
    storeKeyDiv.innerText='Store';
    const storeValDiv=document.createElement('div');
    storeValDiv.classList.add('store-val');
    storeValDiv.innerText=sale.store===undefined?'':sale.store;
    col1.appendChild(storeKeyDiv);
    col2.appendChild(storeValDiv);
    const posKeyDiv=document.createElement('div');
    posKeyDiv.classList.add('pos-key');
    posKeyDiv.innerText='POS';
    const posValDiv=document.createElement('div');
    posValDiv.classList.add('pos-val');
    posValDiv.innerText=sale.pos===undefined?'':sale.pos;
    col1.appendChild(posKeyDiv);
    col2.appendChild(posValDiv);
    const userKeyDiv=document.createElement('div');
    userKeyDiv.classList.add('user-key');
    userKeyDiv.innerText='POS User';
    const userValDiv=document.createElement('div');
    userValDiv.classList.add('user-val');
    userValDiv.innerText=sale.user===undefined?'':sale.user;
    col1.appendChild(userKeyDiv);
    col2.appendChild(userValDiv);
    const customerKeyDiv=document.createElement('div');
    customerKeyDiv.classList.add('customer-key');
    customerKeyDiv.innerText='Customer';
    const customerValDiv=document.createElement('div');
    customerValDiv.classList.add('customer-val');
    customerValDiv.innerText=sale.customer===undefined?'':sale.customer;
    col1.appendChild(customerKeyDiv);
    col2.appendChild(customerValDiv);
    const payedKeyDiv=document.createElement('div');
    payedKeyDiv.classList.add('payed-key');
    payedKeyDiv.innerText='Payed';
    const payedValDiv=document.createElement('div');
    payedValDiv.classList.add('payed-val');
    payedValDiv.innerText=sale.payed===undefined?'':sale.payed;
    col1.appendChild(payedKeyDiv);
    col2.appendChild(payedValDiv);
    const createdKeyDiv=document.createElement('div');
    createdKeyDiv.classList.add('created-key');
    createdKeyDiv.innerText='Created at';
    const createdValDiv=document.createElement('div');
    createdValDiv.classList.add('created-val');
    createdValDiv.innerText=sale.dateCreated===undefined?date:sale.dateCreated;
    col1.appendChild(createdKeyDiv);
    col2.appendChild(createdValDiv);
    const modifiedKeyDiv=document.createElement('div');
    modifiedKeyDiv.classList.add('modified-key');
    modifiedKeyDiv.innerText='Modified at';
    const modifiedValDiv=document.createElement('div');
    modifiedValDiv.classList.add('modified-val');
    modifiedValDiv.innerText=sale.dateModified===undefined?date:sale.dateModified;
    col1.appendChild(modifiedKeyDiv);
    col2.appendChild(modifiedValDiv);
    const deleteButton=card.querySelector('.card__button-2');
    deleteButton.addEventListener('click', removeSaleCard);
    const editButton=card.querySelector('.card__button-1');
    editButton.addEventListener('click', editSaleCard);
    container.appendChild(card);
}

const submitSale=()=>{
    const idInput=document.querySelector('.id-input');
    const numberInput=document.querySelector('.number-input');
    const storeSelect=document.querySelector('.store-select');
    const posSelect=document.querySelector('.pos-select');
    const userSelect=document.querySelector('.user-select');
    const customerInput=document.querySelector('.customer-input');
    const payedSelect=document.querySelector('.payed-select');
    const createdInput=document.querySelector('.created-at-input');
    const modifiedInput=document.querySelector('.modified-at-input');
    const sale={};
    sale.id=idInput.value;
    sale.saleDocNum=numberInput.value;
    sale.store=storeSelect.value;
    sale.pos=posSelect.value;
    sale.user=userSelect.value;
    sale.customer=customerInput.value;
    sale.payed=payedSelect.value;
    sale.dateCreated=createdInput.value;
    sale.dateModified=modifiedInput.value;
    addSaleToTable(sale);
}

const removeSaleFromTable=(e)=>{
    const sale=e.target.parentNode.parentNode;
    sale.remove();
}

const clearTable=()=>{
    const dataRows=document.querySelectorAll('.data-row');
    dataRows.forEach(element => {
        element.remove();
    });
}

const removeSaleCard=(e)=>{
    const card=e.target.parentNode.parentNode.parentNode;
    card.remove();
}

const clearCards=()=>{
    const dataCards=document.querySelectorAll('.data-card');
    dataCards.forEach(element => {
        element.remove();
    });
}

const editSaleInTable=(e)=>{
    const sale=e.target.parentNode.parentNode;
    sale.classList.add('table__form');
    const idCell=sale.querySelector('.id-cell');
    const numberCell=sale.querySelector('.number-cell');
    const storeCell=sale.querySelector('.store-cell');
    const posCell=sale.querySelector('.pos-cell');
    const userCell=sale.querySelector('.user-cell');
    const customerCell=sale.querySelector('.customer-cell');
    const payedCell=sale.querySelector('.payed-cell');
    const createdCell=sale.querySelector('.created-cell');
    const modifiedCell=sale.querySelector('.modified-cell');
    const editButton=sale.querySelector('.table-button-1');
    editButton.classList.replace('edit-button', 'submit-button');
    editButton.removeEventListener('click', editSaleInTable);
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
    const numberInput=document.createElement('input');
    const numberAtr = document.createAttribute("name");      
    numberAtr.value = "sales-doc-number";                           
    numberInput.setAttributeNode(numberAtr);
    const reqNumberAtr = document.createAttribute("required");
    numberInput.setAttributeNode(reqNumberAtr);
    numberInput.classList.add('number-input');
    numberInput.classList.add('input');
    numberInput.value=numberCell.innerText;
    numberCell.innerText='';
    numberCell.appendChild(numberInput);
    const storeContainer=document.createElement('span');
    storeContainer.classList.add('select');
    const storeSelect=document.createElement('select');
    storeSelect.classList.add('store-select');
    storeSelect.classList.add('select');
    stores.forEach(store => {
        const option=document.createElement('option');
        option.innerText=store.name;
        storeSelect.appendChild(option);
    });
    storeSelect.value=storeCell.innerText;
    storeCell.innerText='';
    storeContainer.appendChild(storeSelect);
    storeCell.appendChild(storeContainer);
    const posContainer=document.createElement('span');
    posContainer.classList.add('select');
    const posSelect=document.createElement('select');
    posSelect.classList.add('pos-select');
    posSelect.classList.add('select');
    pos.forEach(pos => {
        const option=document.createElement('option');
        option.innerText=pos.id;
        posSelect.appendChild(option);
    });
    posSelect.value=posCell.innerText;
    posCell.innerText='';
    posContainer.appendChild(posSelect);
    posCell.appendChild(posContainer);
    const userContainer=document.createElement('span');
    userContainer.classList.add('select');
    const userSelect=document.createElement('select');
    userSelect.classList.add('user-select');
    userSelect.classList.add('select');
    users.forEach(user => {
        const option=document.createElement('option');
        option.innerText=user.name;
        userSelect.appendChild(option);
    });
    userSelect.value=userCell.innerText;
    userCell.innerText='';
    userContainer.appendChild(userSelect);
    userCell.appendChild(userContainer);
    const customerInput=document.createElement('input');
    const customerAtr = document.createAttribute("name");      
    customerAtr.value = "customer";                           
    customerInput.setAttributeNode(customerAtr);
    customerInput.classList.add('customer-input');
    customerInput.classList.add('input');
    customerInput.value=customerCell.innerText;
    customerCell.innerText='';
    customerCell.appendChild(customerInput);
    const payedContainer=document.createElement('span');
    payedContainer.classList.add('select');
    const payedSelect=document.createElement('select');
    payedSelect.classList.add('payed-select');
    payedSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    payedSelect.appendChild(trueOption);
    payedSelect.appendChild(falseOption);
    payedSelect.value=payedCell.innerText;
    payedCell.innerText='';
    payedContainer.appendChild(payedSelect);
    payedCell.appendChild(payedContainer);
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
    const inputList=sale.querySelectorAll('.input');
    inputList.forEach(element => {
        element.addEventListener('blur', validateInput);
    });
}

const editSaleCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.add('card-form');
    const idDiv=card.querySelector('.id-val');
    const numberDiv=card.querySelector('.number-val');
    const storeDiv=card.querySelector('.store-val');
    const posDiv=card.querySelector('.pos-val');
    const userDiv=card.querySelector('.user-val');
    const customerDiv=card.querySelector('.customer-val');
    const payedDiv=card.querySelector('.payed-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__edit-button', 'card__save-button');
    editButton.removeEventListener('click', editSaleCard);
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
    const numberInput=document.createElement('input');
    const numberAtr = document.createAttribute("name");      
    numberAtr.value = "sales-doc-number";                           
    numberInput.setAttributeNode(numberAtr);
    const reqNumberAtr = document.createAttribute("required");
    numberInput.setAttributeNode(reqNumberAtr);
    numberInput.classList.add('number-input');
    numberInput.classList.add('input');
    numberInput.placeholder='Sales Doc Number';
    numberInput.value=numberDiv.innerText;
    numberDiv.innerText='';
    numberDiv.appendChild(numberInput);
    const storeSelect=document.createElement('select');
    storeSelect.classList.add('store-select');
    storeSelect.classList.add('select');
    stores.forEach(store => {
        const option=document.createElement('option');
        option.innerText=store.name;
        storeSelect.appendChild(option);
    });
    if(storeDiv.innerText!=='')
    {
        storeSelect.value=storeDiv.innerText;
        storeDiv.innerText='';
    }else{
        storeSelect.options.selectedIndex=0;
    }
    storeDiv.appendChild(storeSelect);
    const posSelect=document.createElement('select');
    posSelect.classList.add('pos-select');
    posSelect.classList.add('select');
    pos.forEach(pos => {
        const option=document.createElement('option');
        option.innerText=pos.id;
        posSelect.appendChild(option);
    });
    if(posDiv.innerText!=='')
    {
        posSelect.value=posDiv.innerText;
        posDiv.innerText='';
    }else{
        posSelect.options.selectedIndex=0;
    }
    posDiv.appendChild(posSelect);
    const userSelect=document.createElement('select');
    userSelect.classList.add('user-select');
    userSelect.classList.add('select');
    users.forEach(user => {
        const option=document.createElement('option');
        option.innerText=user.name;
        userSelect.appendChild(option);
    });
    if(userDiv.innerText!=='')
    {
        userSelect.value=userDiv.innerText;
        userDiv.innerText='';
    }else{
        userSelect.options.selectedIndex=0;
    }
    userDiv.appendChild(userSelect);
    const customerInput=document.createElement('input');
    const customerAtr = document.createAttribute("name");      
    customerAtr.value = "customer";                           
    customerInput.setAttributeNode(customerAtr);
    customerInput.classList.add('customer-input');
    customerInput.classList.add('input');
    customerInput.placeholder='Customer';
    customerInput.value=customerDiv.innerText;
    customerDiv.innerText='';
    customerDiv.appendChild(customerInput);
    const payedSelect=document.createElement('select');
    payedSelect.classList.add('payed-select');
    payedSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    payedSelect.appendChild(trueOption);
    payedSelect.appendChild(falseOption);
    if(payedDiv.innerText!=='')
    {
        payedSelect.value=payedDiv.innerText;
        payedDiv.innerText='';
    }else{
        payedSelect.options.selectedIndex=0;
    }
    payedDiv.appendChild(payedSelect);
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

const saveSaleCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.remove('card-form');
    const idDiv=card.querySelector('.id-val');
    const numberDiv=card.querySelector('.number-val');
    const storeDiv=card.querySelector('.store-val');
    const posDiv=card.querySelector('.pos-val');
    const userDiv=card.querySelector('.user-val');
    const customerDiv=card.querySelector('.customer-val');
    const payedDiv=card.querySelector('.payed-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__save-button', 'card__edit-button');
    editButton.removeEventListener('click', validateForm);
    editButton.addEventListener('click', editSaleCard);
    const idInput=card.querySelector('.id-input');
    const numberInput=card.querySelector('.number-input');
    const storeSelect=card.querySelector('.store-select');
    const posSelect=card.querySelector('.pos-select');
    const userSelect=card.querySelector('.user-select');
    const customerInput=card.querySelector('.customer-input');
    const payedSelect=card.querySelector('.payed-select');
    const createdInput=card.querySelector('.created-at-input');
    const modifiedInput=card.querySelector('.modified-at-input');
    const sale={};
    sale.id=idInput.value;
    sale.saleDocNum=numberInput.value;
    sale.store=storeSelect.value;
    sale.pos=posSelect.value;
    sale.user=userSelect.value;
    sale.customer=customerInput.value;
    sale.payed=payedSelect.value;
    sale.dateCreated=createdInput.value;
    sale.dateModified=modifiedInput.value;
    idDiv.innerText=sale.id;
    numberDiv.innerText=sale.saleDocNum;
    storeDiv.innerText=sale.store;
    posDiv.innerText=sale.pos;
    userDiv.innerText=sale.user;
    customerDiv.innerText=sale.customer;
    payedDiv.innerText=sale.payed;
    createdDiv.innerText=sale.dateCreated;
    modifiedDiv.innerText=sale.dateModified;
}

//  fill table with data
fillSales(sales);

//  add view-mode event listener
const tableModeButton=document.querySelector('.view-options__table');
tableModeButton.addEventListener('click', ()=>{
    if(!viewMode)
    {
        viewMode=true;
        fillSales(sales);
    }
})
const cardModeButton=document.querySelector('.view-options__card');
cardModeButton.addEventListener('click', ()=>{
    if(viewMode)
    {
        viewMode=false;
        fillSales(sales);
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
        submitSale();
        if(newItem){
            const form=document.querySelector('form');
            form.reset();
            addButton.click();
            newItem=false;
        }else{
            formRow.remove();
        }
    }else{
        saveSaleCard(e);
    }
}

//  add sale event listener
const addButton=document.querySelector('.add-sale-button');
const form=document.querySelector('.table__form');
addButton.addEventListener('click', function(){
    if(viewMode)
    {
        form.classList.toggle('hidden');
        this.classList.toggle('hide-button');
        this.classList.toggle('add-sale-button');
        const inputList=form.querySelectorAll('.input');
        inputList.forEach(element => {
            element.addEventListener('blur', validateInput);
        });
        const storeSelect=document.querySelector('.store-select');
        stores.forEach(store => {
            const option=document.createElement('option');
            option.innerText=store.name;
            storeSelect.appendChild(option);
        });
        const posSelect=document.querySelector('.pos-select');
        pos.forEach(pos => {
            const option=document.createElement('option');
            option.innerText=pos.id;
            posSelect.appendChild(option);
        });
        const userSelect=document.querySelector('.user-select');
        users.forEach(user => {
            const option=document.createElement('option');
            option.innerText=user.name;
            userSelect.appendChild(option);
        });
        newItem=true;
    }else{
        const emptySale={ };
        addSaleToCard(emptySale);
        const lastCard=document.querySelector('.cards-container').lastChild;
        const editButton=lastCard.querySelector('.card__button-1');
        editButton.click();
    }
});

//  submit new product form event listener
const submitButton=document.querySelector('.submit-button');
submitButton.addEventListener('click', validateForm);
import {stores, stocks} from '../data/index.js';

let viewMode=true;  //table mode
let newItem=false;  //add new stock mode

const fillStocks=(stocks)=>{
    const table=document.querySelector('.table-container');
    const card=document.querySelector('.cards-container');
    if(viewMode){
        clearTable();
        stocks.forEach(element => {
            table.classList.remove('hidden');
            card.classList.add('hidden');
            card.classList.remove('columns');
            addStockToTable(element);
        })
    }else{
        clearCards();
        stocks.forEach(element => {
            table.classList.add('hidden');
            card.classList.remove('hidden');
            card.classList.add('columns');
            addStockToCard(element);
        })
    }
}

const addStockToTable=(stock)=>{
    const row=document.createElement('tr');
    row.classList.add('data-row');
    const idCell=document.createElement('td');
    idCell.classList.add('id-cell');
    idCell.innerText=stock.id;
    row.appendChild(idCell);
    const productCell=document.createElement('td');
    productCell.classList.add('product-cell');
    productCell.innerText=stock.product;
    row.appendChild(productCell);
    const storeCell=document.createElement('td');
    storeCell.classList.add('store-cell');
    storeCell.innerText=stock.store;
    row.appendChild(storeCell);
    const quantityCell=document.createElement('td');
    quantityCell.classList.add('quantity-cell');
    quantityCell.innerText=stock.quantity;
    row.appendChild(quantityCell);
    const quantityBaseCell=document.createElement('td');
    quantityBaseCell.classList.add('quantity-base-cell');
    quantityBaseCell.innerText=stock.quantityBase;
    row.appendChild(quantityBaseCell);
    const saleUnitCell=document.createElement('td');
    saleUnitCell.classList.add('sale-unit-cell');
    saleUnitCell.innerText=stock.saleUnit;
    row.appendChild(saleUnitCell);
    const qtySaleUnitCell=document.createElement('td');
    qtySaleUnitCell.classList.add('quantity-sale-cell');
    qtySaleUnitCell.innerText=stock.quantitySaleUnit;
    row.appendChild(qtySaleUnitCell);
    const createdCell=document.createElement('td');
    createdCell.classList.add('created-cell');
    createdCell.innerText=stock.dateCreated;
    row.appendChild(createdCell);
    const modifiedCell=document.createElement('td');
    modifiedCell.classList.add('modified-cell');
    modifiedCell.innerText=stock.dateModified;
    row.appendChild(modifiedCell);
    const editCell=document.createElement('td');
    const editButton=document.createElement('div');
    editButton.classList.add('edit-button');
    editButton.classList.add('table-button-1');
    editCell.appendChild(editButton);
    editButton.addEventListener('click', editStockInTable);
    row.appendChild(editCell);
    const deleteCell=document.createElement('td');
    const deleteButton=document.createElement('button');
    deleteButton.classList.add('delete');
    deleteCell.appendChild(deleteButton);
    deleteButton.addEventListener('click', removeStockFromTable);
    row.appendChild(deleteCell);
    const content=document.querySelector('.table__content');
    const form=document.querySelector('.table__form');
    content.insertBefore(row, form);
}

const addStockToCard=(stock)=>{
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
    idValDiv.innerText=stock.id===undefined?'':stock.id;
    col1.appendChild(idKeyDiv);
    col2.appendChild(idValDiv);
    const productKeyDiv=document.createElement('div');
    productKeyDiv.classList.add('product-key');
    productKeyDiv.innerText='Product Name';
    const productValDiv=document.createElement('div');
    productValDiv.classList.add('product-val');
    productValDiv.innerText=stock.product===undefined?'':stock.product;
    col1.appendChild(productKeyDiv);
    col2.appendChild(productValDiv);
    const storeKeyDiv=document.createElement('div');
    storeKeyDiv.classList.add('store-key');
    storeKeyDiv.innerText='Store';
    const storeValDiv=document.createElement('div');
    storeValDiv.classList.add('store-val');
    storeValDiv.innerText=stock.store===undefined?'':stock.store;
    col1.appendChild(storeKeyDiv);
    col2.appendChild(storeValDiv);
    const quantityKeyDiv=document.createElement('div');
    quantityKeyDiv.classList.add('quantity-key');
    quantityKeyDiv.innerText='Quantity';
    const quantityValDiv=document.createElement('div');
    quantityValDiv.classList.add('quantity-val');
    quantityValDiv.innerText=stock.quantity===undefined?'':stock.quantity;
    col1.appendChild(quantityKeyDiv);
    col2.appendChild(quantityValDiv);
    const quantityBaseKeyDiv=document.createElement('div');
    quantityBaseKeyDiv.classList.add('quantity-base-key');
    quantityBaseKeyDiv.innerText='Quantity Base';
    const quantityBaseValDiv=document.createElement('div');
    quantityBaseValDiv.classList.add('quantity-base-val');
    quantityBaseValDiv.innerText=stock.quantityBase===undefined?'':stock.quantityBase;
    col1.appendChild(quantityBaseKeyDiv);
    col2.appendChild(quantityBaseValDiv);
    const saleUnitKeyDiv=document.createElement('div');
    saleUnitKeyDiv.classList.add('sale-unit-key');
    saleUnitKeyDiv.innerText='Sale Unit';
    const saleUnitValDiv=document.createElement('div');
    saleUnitValDiv.classList.add('sale-unit-val');
    saleUnitValDiv.innerText=stock.saleUnit===undefined?'':stock.saleUnit;
    col1.appendChild(saleUnitKeyDiv);
    col2.appendChild(saleUnitValDiv);
    const qtySaleUnitKeyDiv=document.createElement('div');
    qtySaleUnitKeyDiv.classList.add('qty-sale-unit-key');
    qtySaleUnitKeyDiv.innerText='Quantity Sale Unit';
    const qtySaleUnitValDiv=document.createElement('div');
    qtySaleUnitValDiv.classList.add('qty-sale-unit-val');
    qtySaleUnitValDiv.innerText=stock.quantitySaleUnit===undefined?'':stock.quantitySaleUnit;
    col1.appendChild(qtySaleUnitKeyDiv);
    col2.appendChild(qtySaleUnitValDiv);
    const createdKeyDiv=document.createElement('div');
    createdKeyDiv.classList.add('created-key');
    createdKeyDiv.innerText='Created at';
    const createdValDiv=document.createElement('div');
    createdValDiv.classList.add('created-val');
    createdValDiv.innerText=stock.dateCreated===undefined?date:stock.dateCreated;
    col1.appendChild(createdKeyDiv);
    col2.appendChild(createdValDiv);
    const modifiedKeyDiv=document.createElement('div');
    modifiedKeyDiv.classList.add('modified-key');
    modifiedKeyDiv.innerText='Modified at';
    const modifiedValDiv=document.createElement('div');
    modifiedValDiv.classList.add('modified-val');
    modifiedValDiv.innerText=stock.dateModified===undefined?date:stock.dateModified;
    col1.appendChild(modifiedKeyDiv);
    col2.appendChild(modifiedValDiv);
    const deleteButton=card.querySelector('.card__button-2');
    deleteButton.addEventListener('click', removeStockCard);
    const editButton=card.querySelector('.card__button-1');
    editButton.addEventListener('click', editStockCard);
    container.appendChild(card);
}

const submitStock=()=>{
    const idInput=document.querySelector('.id-input');
    const nameInput=document.querySelector('.product-name-input');
    const storeSelect=document.querySelector('.store-select');
    const quantityInput=document.querySelector('.quantity-input');
    const quantityBaseInput=document.querySelector('.quantity-base-input');
    const saleUnitSelect=document.querySelector('.sale-unit-select');
    const qtySaleUnitInput=document.querySelector('.quantity-sale-input');
    const createdInput=document.querySelector('.created-at-input');
    const modifiedInput=document.querySelector('.modified-at-input');
    const stock={};
    stock.id=idInput.value;
    stock.product=nameInput.value;
    stock.store=storeSelect.value;
    stock.quantity=quantityInput.value;
    stock.quantityBase=quantityBaseInput.value;
    stock.saleUnit=saleUnitSelect.value;
    stock.quantitySaleUnit=qtySaleUnitInput.value;
    stock.dateCreated=createdInput.value;
    stock.dateModified=modifiedInput.value;
    addStockToTable(stock);
}

const removeStockFromTable=(e)=>{
    const stock=e.target.parentNode.parentNode;
    stock.remove();
}

const clearTable=()=>{
    const dataRows=document.querySelectorAll('.data-row');
    dataRows.forEach(element => {
        element.remove();
    });
}

const removeStockCard=(e)=>{
    const card=e.target.parentNode.parentNode.parentNode;
    card.remove();
}

const clearCards=()=>{
    const dataCards=document.querySelectorAll('.data-card');
    dataCards.forEach(element => {
        element.remove();
    });
}

const editStockInTable=(e)=>{
    const stock=e.target.parentNode.parentNode;
    stock.classList.add('table__form');
    const idCell=stock.querySelector('.id-cell');
    const productCell=stock.querySelector('.product-cell');
    const storeCell=stock.querySelector('.store-cell');
    const quantityCell=stock.querySelector('.quantity-cell');
    const quantityBaseCell=stock.querySelector('.quantity-base-cell');
    const saleUnitCell=stock.querySelector('.sale-unit-cell');
    const qtySaleUnitCell=stock.querySelector('.quantity-sale-cell');
    const createdCell=stock.querySelector('.created-cell');
    const modifiedCell=stock.querySelector('.modified-cell');
    const editButton=stock.querySelector('.table-button-1');
    editButton.classList.replace('edit-button', 'submit-button');
    editButton.removeEventListener('click', editStockInTable);
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
    const productInput=document.createElement('input');
    const productAtr = document.createAttribute("name");      
    productAtr.value = "product-name";                           
    productInput.setAttributeNode(productAtr);
    const reqProductAtr = document.createAttribute("required");
    productInput.setAttributeNode(reqProductAtr);
    productInput.classList.add('product-name-input');
    productInput.classList.add('input');
    productInput.value=productCell.innerText;
    productCell.innerText='';
    productCell.appendChild(productInput);
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
    const quantityInput=document.createElement('input');
    const quantityAtr = document.createAttribute("name");      
    quantityAtr.value = "quantity";                           
    quantityInput.setAttributeNode(quantityAtr);
    quantityInput.classList.add('quantity-input');
    quantityInput.classList.add('input');
    quantityInput.value=quantityCell.innerText;
    quantityCell.innerText='';
    quantityCell.appendChild(quantityInput);
    const quantityBaseInput=document.createElement('input');
    const quantityBaseAtr = document.createAttribute("name");      
    quantityBaseAtr.value = "quantity-base";                           
    quantityBaseInput.setAttributeNode(quantityBaseAtr);
    quantityBaseInput.classList.add('quantity-base-input');
    quantityBaseInput.classList.add('input');
    quantityBaseInput.value=quantityBaseCell.innerText;
    quantityBaseCell.innerText='';
    quantityBaseCell.appendChild(quantityBaseInput);
    const qtySaleUnitInput=document.createElement('input');
    const qtySaleUnitAtr = document.createAttribute("name");      
    qtySaleUnitAtr.value = "quantity-sale-unit";                           
    qtySaleUnitInput.setAttributeNode(qtySaleUnitAtr);
    qtySaleUnitInput.classList.add('quantity-sale-input');
    qtySaleUnitInput.classList.add('input');
    qtySaleUnitInput.value=qtySaleUnitCell.innerText;
    qtySaleUnitCell.innerText='';
    qtySaleUnitCell.appendChild(qtySaleUnitInput);
    const saleUnitContainer=document.createElement('span');
    saleUnitContainer.classList.add('select');
    const saleUnitSelect=document.createElement('select');
    saleUnitSelect.classList.add('sale-unit-select');
    saleUnitSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    saleUnitSelect.appendChild(trueOption);
    saleUnitSelect.appendChild(falseOption);
    saleUnitSelect.value=saleUnitCell.innerText;
    saleUnitCell.innerText='';
    saleUnitContainer.appendChild(saleUnitSelect);
    saleUnitCell.appendChild(saleUnitContainer);
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

const editStockCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.add('card-form');
    const idDiv=card.querySelector('.id-val');
    const productDiv=card.querySelector('.product-val');
    const storeDiv=card.querySelector('.store-val');
    const quantityDiv=card.querySelector('.quantity-val');
    const quantityBaseDiv=card.querySelector('.quantity-base-val');
    const saleUnitDiv=card.querySelector('.sale-unit-val');
    const qtySaleUnitDiv=card.querySelector('.qty-sale-unit-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__edit-button', 'card__save-button');
    editButton.removeEventListener('click', editStockCard);
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
    const productInput=document.createElement('input');
    const productAtr = document.createAttribute("name");      
    productAtr.value = "product-name";                           
    productInput.setAttributeNode(productAtr);
    const reqProductAtr = document.createAttribute("required");
    productInput.setAttributeNode(reqProductAtr);
    productInput.classList.add('product-name-input');
    productInput.classList.add('input');
    productInput.placeholder='Product Name';
    productInput.value=productDiv.innerText;
    productDiv.innerText='';
    productDiv.appendChild(productInput);
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
    const quantityInput=document.createElement('input');
    const quantityAtr = document.createAttribute("name");      
    quantityAtr.value = "quantity";                           
    quantityInput.setAttributeNode(quantityAtr);
    quantityInput.classList.add('quantity-input');
    quantityInput.classList.add('input');
    quantityInput.placeholder='Quantity';
    quantityInput.value=quantityDiv.innerText;
    quantityDiv.innerText='';
    quantityDiv.appendChild(quantityInput);
    const quantityBaseInput=document.createElement('input');
    const quantityBaseAtr = document.createAttribute("name");      
    quantityBaseAtr.value = "quantity-base";                           
    quantityBaseInput.setAttributeNode(quantityBaseAtr);
    quantityBaseInput.classList.add('quantity-base-input');
    quantityBaseInput.classList.add('input');
    quantityBaseInput.placeholder='Quantity Base';
    quantityBaseInput.value=quantityBaseDiv.innerText;
    quantityBaseDiv.innerText='';
    quantityBaseDiv.appendChild(quantityBaseInput);
    const qtySaleUnitInput=document.createElement('input');
    const qtySaleUnitAtr = document.createAttribute("name");      
    qtySaleUnitAtr.value = "quantity-sale";                           
    qtySaleUnitInput.setAttributeNode(qtySaleUnitAtr);
    qtySaleUnitInput.classList.add('quantity-sale-input');
    qtySaleUnitInput.classList.add('input');
    qtySaleUnitInput.placeholder='Quantity Sale Unit';
    qtySaleUnitInput.value=qtySaleUnitDiv.innerText;
    qtySaleUnitDiv.innerText='';
    qtySaleUnitDiv.appendChild(qtySaleUnitInput);
    const saleUnitSelect=document.createElement('select');
    saleUnitSelect.classList.add('sale-unit-select');
    saleUnitSelect.classList.add('select');
    const trueOption=document.createElement('option');
    const falseOption=document.createElement('option');
    trueOption.innerText='true';
    falseOption.innerText='false';
    saleUnitSelect.appendChild(trueOption);
    saleUnitSelect.appendChild(falseOption);
    if(saleUnitDiv.innerText!=='')
    {
        saleUnitSelect.value=saleUnitDiv.innerText;
        saleUnitDiv.innerText='';
    }else{
        saleUnitSelect.options.selectedIndex=0;
    }
    saleUnitDiv.appendChild(saleUnitSelect);
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

const saveStockCard=(e)=>{
    const card=e.target.parentNode.parentNode;
    const dataColumn=card.querySelector('.content__data__column-2');
    dataColumn.classList.remove('card-form');
    const idDiv=card.querySelector('.id-val');
    const productDiv=card.querySelector('.product-val');
    const storeDiv=card.querySelector('.store-val');
    const quantityDiv=card.querySelector('.quantity-val');
    const quantityBaseDiv=card.querySelector('.quantity-base-val');
    const saleUnitDiv=card.querySelector('.sale-unit-val');
    const qtySaleUnitDiv=card.querySelector('.quantity-sale-val');
    const createdDiv=card.querySelector('.created-val');
    const modifiedDiv=card.querySelector('.modified-val');
    const editButton=card.querySelector('.card__button-1');
    editButton.classList.replace('card__save-button', 'card__edit-button');
    editButton.removeEventListener('click', validateForm);
    editButton.addEventListener('click', editStockCard);
    const idInput=card.querySelector('.id-input');
    const productInput=card.querySelector('.product-name-input');
    const storeSelect=card.querySelector('.store-select');
    const quantityInput=card.querySelector('.quantity-input');
    const quantityBaseInput=card.querySelector('.quantity-base-input');
    const qtySaleUnitInput=card.querySelector('.quantity-sale-input');
    const saleUnitSelect=card.querySelector('.sale-unit-select');
    const createdInput=card.querySelector('.created-at-input');
    const modifiedInput=card.querySelector('.modified-at-input');
    const stock={};
    stock.id=idInput.value;
    stock.product=productInput.value;
    stock.store=storeSelect.value;
    stock.quantity=quantityInput.value;
    stock.quantityBase=quantityBaseInput.value;
    stock.quantitySaleUnit=qtySaleUnitInput.value;
    stock.saleUnit=saleUnitSelect.value;
    stock.dateCreated=createdInput.value;
    stock.dateModified=modifiedInput.value;
    idDiv.innerText=stock.id;
    productDiv.innerText=stock.product;
    storeDiv.innerText=stock.store;
    quantityDiv.innerText=stock.quantity;
    quantityBaseDiv.innerText=stock.quantityBase;
    saleUnitDiv.innerText=stock.saleUnit;
    qtySaleUnitDiv.innerText=stock.quantitySaleUnit;
    createdDiv.innerText=stock.dateCreated;
    modifiedDiv.innerText=stock.dateModified;
}

//  fill table with data
fillStocks(stocks);

//  add view-mode event listener
const tableModeButton=document.querySelector('.view-options__table');
tableModeButton.addEventListener('click', ()=>{
    if(!viewMode)
    {
        viewMode=true;
        fillStocks(stocks);
    }
})
const cardModeButton=document.querySelector('.view-options__card');
cardModeButton.addEventListener('click', ()=>{
    if(viewMode)
    {
        viewMode=false;
        fillStocks(stocks);
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
        submitStock();
        if(newItem){
            const form=document.querySelector('form');
            form.reset();
            addButton.click();
            newItem=false;
        }else{
            formRow.remove();
        }
    }else{
        saveStockCard(e);
    }
}

//  add product event listener
const addButton=document.querySelector('.add-stock-button');
const form=document.querySelector('.table__form');
addButton.addEventListener('click', function(){
    if(viewMode)
    {
        form.classList.toggle('hidden');
        this.classList.toggle('hide-button');
        this.classList.toggle('add-stock-button');
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
        newItem=true;
    }else{
        const emptyStock={ };
        addStockToCard(emptyStock);
        const lastCard=document.querySelector('.cards-container').lastChild;
        const editButton=lastCard.querySelector('.card__button-1');
        editButton.click();
    }
});

//  submit new product form event listener
const submitButton=document.querySelector('.submit-button');
submitButton.addEventListener('click', validateForm);
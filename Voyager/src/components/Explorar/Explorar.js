import { ActivityIndicator, FlatList, ScrollView } from "react-native"
import { CardExplorar } from "../CardExplorar/CardExplorar"
import { SearchBar } from "../Search/style"
import { ContainerExplorar, ContainerList, LoadingContent } from "./style"
import { Grid } from "react-native-easy-grid"
import api from "../../service/Service";
import { TitleDefault } from "../Text/style"
import { useEffect, useState } from "react"


export const Explorar = () => {
    const [searchText, setSearchText] = useState("")
    const [showLoading, setShowLoading] = useState(false)
    const [placesList, setPlacesList] = useState([])

    const HandleSearch = (place) => {
        setShowLoading(true)
        api.post(`/PlaceSearch?local=${place}`).then(response => {
            setPlacesList(response.data)
            setShowLoading(false)
        }).catch(erro => {
            alert(erro)
            setShowLoading(false)
        })
        
    }

    return (
        <ContainerExplorar>
            <SearchBar placeholder={`Explorar...`} value={searchText} onChangeText={text => setSearchText(text)} onSubmitEditing={() => {
                setShowLoading(true)
                HandleSearch(searchText)
            }} />

            {showLoading ?
                <LoadingContent>
                    <TitleDefault>
                        Buscando!
                    </TitleDefault>
                    <ActivityIndicator  color={"#8531C6"} />
                </LoadingContent>
                :
                null}

            {placesList.length === 0 && !showLoading ?
                <LoadingContent>
                    <TitleDefault>
                        Informe um local!
                    </TitleDefault>
                </LoadingContent>
                : null}

            {placesList.length > 0 && !showLoading ?
                <ContainerList>
                    <Grid style={{ padding: 15 }}>
                        <FlatList
                            horizontal={false}
                            data={placesList}
                            renderItem={({ item }) => <CardExplorar urlImage={item.imagem} title={item.nome} />}
                            numColumns={2}
                            showsVerticalScrollIndicator={false}
                        />
                    </Grid>
                </ContainerList>
                : null}
        </ContainerExplorar>
    )
}